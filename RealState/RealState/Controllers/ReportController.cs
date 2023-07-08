using Microsoft.AspNetCore.Mvc;
using RealState.Core.NotMapped;

namespace RealState.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Income(TransactionQuery model)
        {
            model.SortBy = "Created";
            model.PageSize = 10;

            return View();
        }
    }
}
