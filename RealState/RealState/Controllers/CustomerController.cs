using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealState.Models;
using RealState.Models.CustomerModels;
using RealState.Models.PlotModels;
using System.Collections.Generic;

namespace RealState.Controllers
{
    [Authorize]
    public class CustomerController : Controller
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
        [ValidateAntiForgeryToken]
        public IActionResult Add(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                var model = new CustomerUpdateModel();
                model.AddNewCustomer(customer);
                return RedirectToAction(nameof(CustomerController.Index));
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new CustomerViewModel();
            var allCustomer = model.GetCustomers(tableModel);
            return Json(allCustomer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = new CustomerViewModel();
            CustomerModel customerModel = viewModel.Load(id);
            return View(customerModel);

        }

        [HttpPost]
        public IActionResult Edit(CustomerModel model)
        {
            var customerUpdateModel = new CustomerUpdateModel();
            customerUpdateModel.UpdateCustomer(model);
            return RedirectToAction(nameof(CustomerController.Index));

        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var model = new CustomerUpdateModel();
            model.DeleteCustomer(Id);
            return RedirectToAction(nameof(CustomerController.Index));

        }


        public JsonResult FindCustomer()
        {
            var customerVM = new CustomerViewModel();
            var customers = customerVM.FindAllCustomer();

            return new JsonResult(customers);
        }

    }
}
