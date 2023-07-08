using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RealState.Models.TransactionModels;
using System.IO;
using System;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using RealState.Models;
using RealState.Models.BlockModels;
using Microsoft.AspNetCore.Authorization;

namespace RealState.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public TransactionController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult GetExpenses()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetIncome()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateExpense()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(TransactionModel transactionModel)
        {

            var trasacModel = new TransactionUM();
            string webRootPath = _hostEnvironment.WebRootPath;

            if (transactionModel.ImageFile != null && transactionModel.ImageFile.Length > 0)
            {

                string fileName = transactionModel.ImageFile.FileName;
                var filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await transactionModel.ImageFile.CopyToAsync(fileStream);
                }

                transactionModel.ImageUrl = fileName;
            }


            trasacModel.AddExpense(transactionModel);
            return RedirectToAction("GetExpenses");

        }

        [HttpGet]
        public IActionResult CreateIncome()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncome(TransactionModel transactionModel)
        {

            var trasacModel = new TransactionUM();
            string webRootPath = _hostEnvironment.WebRootPath;

            if (transactionModel.ImageFile != null && transactionModel.ImageFile.Length > 0)
            {

                string fileName = transactionModel.ImageFile.FileName;
                var filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await transactionModel.ImageFile.CopyToAsync(fileStream);
                }

                transactionModel.ImageUrl = fileName;
            }


            trasacModel.AddIncome(transactionModel);
            return RedirectToAction("GetIncome");



        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = new TransactionUM();
            model.DeleteTransaction(id);
            return RedirectToAction("GetExpenses");

        }

        [HttpGet]
        public IActionResult GetAllExpense()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var transacModel = new TransactionVM();
            var transactions = transacModel.GetExpenses(tableModel);
            return Json(transactions);
        }


        [HttpGet]
        public IActionResult FindAllExpenses()
        {
            var transacModel = new TransactionUM();
            var transactions = transacModel.GetExpenses();
            return Json(transactions);
        }


        [HttpGet]
        public IActionResult GetAllIncome()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var transacModel = new TransactionVM();
            var transactions = transacModel.GetIncome(tableModel);
            return Json(transactions);
        }

        [HttpGet]
        public IActionResult ListIncome()
        {
            var transactionModel = new TransactionVM();
            var allIncome = transactionModel.GetIncome();
            return View(allIncome);
        }

        [HttpGet]
        public JsonResult GetIncomeByCategory(int id)
        {
            var transactionModel = new TransactionVM();
            var allIncome = transactionModel.IncomeByCategory(id);
            var jsonObj = new JsonResult(allIncome);
            return jsonObj;
        }


    }
}
