using Microsoft.AspNetCore.Mvc;
using RealState.Models.BlockModels;
using RealState.Models;
using RealState.Models.PlotModels;
using Microsoft.AspNetCore.Authorization;

namespace RealState.Controllers
{
    [Authorize]
    public class PlotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PlotModel plotModel)
        {
            if (ModelState.IsValid)
            {
                var plotUM = new PlotUpdateModel();
                plotUM.CreateNewPlot(plotModel);
                return RedirectToAction(nameof(Index));
            }
            return View(plotModel);
        }

        [HttpGet]
        public IActionResult GetPlots()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new PlotViewModel();
            var plots = model.GetPlots(tableModel);
            return Json(plots);
        }

        public JsonResult FindPlotByBlockId(int id)
        {
            var plotVM = new PlotViewModel();
            var plots = plotVM.GetPlotByBlockId(id);

            return new JsonResult(plots);
        }
    }
}
