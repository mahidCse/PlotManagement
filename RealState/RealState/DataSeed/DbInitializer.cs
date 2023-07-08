using Microsoft.AspNetCore.Identity;
using RealState.Data;
using System.Threading.Tasks;
using System;
using RealState.Core.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RealState.SD;

namespace RealState.DataSeed
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext applicationDbContext;
        private readonly RealStateContext realStateContext;
        public DbInitializer(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, ApplicationDbContext applicationDbContext, RealStateContext realStateContext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.applicationDbContext = applicationDbContext;
            this.realStateContext = realStateContext;
        }
        public async Task InitializeAsync()
        {
            // Add pending migrations if exists
            if (applicationDbContext.Database.GetPendingMigrations().Count() > 0)
            {
                applicationDbContext.Database.Migrate();
            }

            if (realStateContext.Database.GetAppliedMigrations().Count() > 0)
            {
                realStateContext.Database.Migrate();
            }

            // Return if Admin role exists
            if (applicationDbContext.Roles.Any(x => x.Name == "Admin"))
            {
                return;
            }

            // Create Admin Role
            roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();

            // Create other Role
            roleManager.CreateAsync(new IdentityRole(RoleType.Role_Manager)).GetAwaiter().GetResult();
            roleManager.CreateAsync(new IdentityRole(RoleType.Role_Employee)).GetAwaiter().GetResult();

            //Create user 
            userManager.CreateAsync(new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
            }, "Abc@123").GetAwaiter().GetResult();

            // Assign role to admin user
            await userManager.AddToRoleAsync(await userManager.FindByEmailAsync("admin@gmail.com"), "Admin");
        }


    }
}
