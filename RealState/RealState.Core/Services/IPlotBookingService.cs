using RealState.Core.Entity;
using System.Collections.Generic;

namespace RealState.Core.Services
{
    public interface IPlotBookingService
    {
        void BookNewPlot(PlotBooking plotBook);
        IEnumerable<PlotBooking> GetBookedPlot(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered);
        IEnumerable<PlotBooking> GetBookedPlots();
        void Delete(int id);
        PlotBooking GetBookedPlot(int id);
    }
}