using RealState.Core.Entity;
using System.Collections;
using System.Collections.Generic;

namespace RealState.Core.Services
{
    public interface IPlotService
    {
        void AddNewPlot(Plot plot);
        IEnumerable<Plot> GetAllPlot();
        Plot GetPlotById(int id);
        void EditPlot(Plot plot);
        void Remove(int id);
        IEnumerable<Plot> GetPlots(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered);
        IEnumerable<Plot> GetPlotsByBlockId(int id);
        void CreateSinglePlot(Plot plot);
    }
}