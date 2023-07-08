using Autofac;
using RealState.Core.Entity;
using RealState.Core.Services;
using System;

namespace RealState.Models.PlotBooking
{
    public class PlotBookingUM
    {
        private IPlotBookingService _plotBookingService;
        private IBlockService _blockService;
        private IPlotService _plotService;
        public PlotBookingUM()
        {
            _plotBookingService = Startup.AutofacContainer.Resolve<IPlotBookingService>();
            _blockService = Startup.AutofacContainer.Resolve<IBlockService>();
            _plotService = Startup.AutofacContainer.Resolve<IPlotService>();
        }


        public void BookNewPlot(PlotBookingModel bookingModel)
        {
            _plotBookingService.BookNewPlot(new Core.Entity.PlotBooking
            {
                CustomerId = bookingModel.CustomerId,
                PlotId = bookingModel.PlotId,
                BookedOn = DateTime.Today.Date
            }) ;

            var plot = _plotService.GetPlotById(bookingModel.PlotId);
            plot.Status = 0;
            _plotService.EditPlot(plot);
        }


        public void VacateBookedPlot(int id)
        {
            var plotId = _plotBookingService.GetBookedPlot(id).PlotId;
            _plotBookingService.Delete(id);

            var plot = _plotService.GetPlotById(plotId);
            plot.Status = 1; // plot status 1 when plot is unbooked
            _plotService.EditPlot(plot);
        }


    }
}
