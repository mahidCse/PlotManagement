using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RealState.Core.Entity;
using RealState.Models;
using RealState.Models.BlockModels;
using RealState.Models.CustomerModels;
using RealState.SD;
using System.Collections.Generic;

namespace RealState.Controllers
{
    [Authorize]
    public class BlockController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public BlockController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
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
        public IActionResult Add(BlockModel blockModel)
        {
            if (ModelState.IsValid)
            {
                var blockUpdateModel = new BlockUpdateModel();
                blockUpdateModel.AddNewBlock(blockModel);
                return RedirectToAction(nameof(BlockController.Index));
            }
            return View(blockModel);
        }

        [HttpGet]
        public IActionResult GetBlocks()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new BlockViewModel();
            var blocks = model.GetBlocks(tableModel);
            return Json(blocks);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = new BlockUpdateModel();
            model.DeleteBlock(id);
            return RedirectToAction(nameof(CustomerController.Index));

        }

        public JsonResult FindBlockList()
        {
            var blockVM = new BlockViewModel();

            var blocks = blockVM.GetBlocks();

            return new JsonResult(blocks);
        }

    }
}
