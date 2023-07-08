using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using RealState.Core.UnitOfWorks;
using RealState.Models;
using RealState.SD;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(ILogger<AccountController> logger, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        [Authorize(Roles =RoleType.Role_Admin)]
        public IActionResult Register(string returnUrl = null)
        {
            var registerModel = new RegisterModel
            {
                ReturnUrl = returnUrl,
                RoleList = _roleManager.Roles.Where(x => x.Name != RoleType.Role_Admin).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(registerModel);

        }

        [HttpPost]
        [Authorize(Roles = RoleType.Role_Admin)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            model.ReturnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                var userExsist = await _userManager.FindByEmailAsync(model.Email);

                if (userExsist == null)
                {
                    var newUser = await _userManager.CreateAsync(user, model.Password);
                    if (newUser.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");

                        if (!await _roleManager.RoleExistsAsync(RoleType.Role_Admin))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(RoleType.Role_Admin));
                        }
                        if (!await _roleManager.RoleExistsAsync(RoleType.Role_Employee))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(RoleType.Role_Employee));
                        }

                        var role = await _roleManager.FindByIdAsync(model.Role);

                        if (role != null)
                        {
                            await _userManager.AddToRoleAsync(user, role.Name);
                        }


                        //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        //var callbackUrl = Url.Action("Index",
                        //    "Home",
                        //    values: new {userId = user.Id, code = code },
                        //    protocol: Request.Scheme);



                        //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                        //{
                        //    return RedirectToAction("RegisterConfirmation", new { email = model.Email });
                        //}
                        //else
                        //{
                        //    if (user.Role == null)
                        //    {
                        //        await _signInManager.SignInAsync(user, isPersistent: false);
                        //        return LocalRedirect(model.ReturnUrl);
                        //    }
                        //    else
                        //    {
                        //        //admin is registering new user
                        //        return RedirectToAction(nameof(Index), "User", new { Area = "Admin" });
                        //    }
                        //}
                    }
                    foreach (var error in newUser.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

                return View();

            }

            // If we got this far, something failed, redisplay form
            // regenerate select List in view
            model.RoleList = _roleManager.Roles.Where(x => x.Name != RoleType.Role_Admin).Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            var model = new LoginModel();
            model.ReturnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            model.ReturnUrl = model.ReturnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    // return RedirectToAction(nameof(HomeController.Index),"Home");
                    return LocalRedirect(model.ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index", "Home");

        }

    }
}
