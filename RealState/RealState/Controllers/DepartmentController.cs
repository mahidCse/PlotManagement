using Microsoft.AspNetCore.Mvc;
using RealState.Models.DepartmentModels;
using RealState.Models;
using Microsoft.AspNetCore.Authorization;

namespace RealState.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(DepartmentModel departmentModel)
        {
            var departmentUM = new DepartmentUM();
            departmentUM.AddNewAccount(departmentModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult GetDepartment()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new DepartmentVM();
            var department = model.GetAccounts(tableModel);
            return Json(department);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = new DepartmentUM();
            model.DeleteAccount(id);
            return RedirectToAction(nameof(CustomerController.Index));

        }

        public JsonResult FindDepartmentList()
        {
            var model = new DepartmentVM();

            var department = model.FindAllaccount();

            return new JsonResult(department);
        }
    }
}
