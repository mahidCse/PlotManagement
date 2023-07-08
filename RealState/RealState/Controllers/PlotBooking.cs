using Microsoft.AspNetCore.Mvc;
using RealState.Models.BlockModels;
using RealState.Models;
using RealState.Models.PlotBooking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using RealState.Hubs;

namespace RealState.Controllers
{
    [Authorize]
    public class PlotBooking : Controller
    {
        private IHubContext<NotificationHub> _hubContext;
        public PlotBooking(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

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
        public IActionResult Create(PlotBookingModel plotBookingModel)
        {
            var bookingUM = new PlotBookingUM();
            bookingUM.BookNewPlot(plotBookingModel);
            var count = new PlotBookingVM().GetBookedPlotCount();
            _hubContext.Clients.All.SendAsync("BookedPlotCount", count);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult GetBookedPlot()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new PlotBookingVM();
            var plots = model.GetBookedPlots(tableModel);
            return Json(plots);
        }

        [HttpGet]
        public IActionResult Vacate(int id)
        {
            var bookingUM = new PlotBookingUM();
            bookingUM.VacateBookedPlot(id);
            var count = new PlotBookingVM().GetBookedPlotCount();
            _hubContext.Clients.All.SendAsync("BookedPlotCount", count);
            return RedirectToAction(nameof(Index));
        }
    }
}
