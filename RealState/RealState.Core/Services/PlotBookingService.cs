using RealState.Core.Context;
using RealState.Core.Entity;
using RealState.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Services
{
    public class PlotBookingService : IPlotBookingService
    {
        private IRealStateUnitOfWork _realStateUnitOfWork;

        public PlotBookingService(IRealStateUnitOfWork realStateUnitOfWork)
        {
            _realStateUnitOfWork = realStateUnitOfWork;
        }

        public void BookNewPlot(PlotBooking plotBook)
        {
            _realStateUnitOfWork.PlotBookingRepository.Add(plotBook);
            _realStateUnitOfWork.Save();
        }

        public IEnumerable<PlotBooking> GetBookedPlot(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            return _realStateUnitOfWork.PlotBookingRepository.Get(

                out total,
                out totalFiltered,
                 x => x.PlotId.ToString().Contains(searchText) || x.CustomerId.ToString().Contains(searchText)
                 || x.BookedOn.ToString().Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }

        public IEnumerable<PlotBooking> GetBookedPlots()
        {
            return _realStateUnitOfWork.PlotBookingRepository.GetAll();
        }

        public PlotBooking GetBookedPlot(int id)
        {
            return _realStateUnitOfWork.PlotBookingRepository.GetById(id);
        }

        public void Delete(int id)
        {
            _realStateUnitOfWork.PlotBookingRepository.Remove(id);
            _realStateUnitOfWork.Save();
        }


    }
}
