using Microsoft.AspNetCore.Mvc;
using RealState.Models.BlockModels;
using RealState.Models;
using RealState.Models.CategoryModels;
using Microsoft.AspNetCore.Authorization;

namespace RealState.Controllers
{
    [Authorize]
    public class CategoryController : Controller
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
        public IActionResult Create(CategoryModel categoryModel)
        {
            var categoryUM = new CategoryUM();
            categoryUM.AddNewCategory(categoryModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new CategoryVM();
            var category = model.GetCategorys(tableModel);
            return Json(category);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = new CategoryUM();
            model.DeleteCategory(id);
            return RedirectToAction(nameof(CustomerController.Index));

        }

        public JsonResult FindCategoryList()
        {
            var model = new CategoryVM();

            var category = model.FindAllCategory();

            return new JsonResult(category);
        }

    }
}
