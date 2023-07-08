using Autofac;
using RealState.Core.Services;
using RealState.Models.BlockModels;
using System.Collections.Generic;
using System.Linq;

namespace RealState.Models.PlotBooking
{
    public class PlotBookingVM
    {
        private IPlotBookingService _bookingService;
        private IPlotService _plotService;
        private ICustomerService _customerService;

        public PlotBookingVM()
        {
            _bookingService = Startup.AutofacContainer.Resolve<IPlotBookingService>();
            _plotService = Startup.AutofacContainer.Resolve<IPlotService>();
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
        }


        public object GetBookedPlots(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _bookingService.GetBookedPlot(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                out total,
                out totalFiltered);

            var bookingModelList = new List<PlotBookingModel>();

            foreach (var bookedPlot in records)
            {
                var plotNumber = _plotService.GetPlotById(bookedPlot.PlotId).PlotNumber;
                var customer = _customerService.GetCustomerById(bookedPlot.CustomerId).Name;

                bookingModelList.Add(new PlotBookingModel
                {
                    Id = bookedPlot.Id,
                    PlotNumber = plotNumber,
                    CustomerName = customer,
                    BookedOn = bookedPlot.BookedOn
                }) ;
            }


            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in bookingModelList
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.CustomerName,
                                record.PlotNumber,
                                record.BookedOn.ToString("dd/MM/yy  hh:mm:ss")

                        }
                    ).ToArray()

            };
        }

        public int GetBookedPlotCount()
        {
            return _bookingService.GetBookedPlots().Count();
        }
    }
}
