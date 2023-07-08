using RealState.Core.Entity;
using RealState.Core.UnitOfWorks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Services
{
    public class PlotService : IPlotService
    {
        private IRealStateUnitOfWork _realStateUnitOfWork;

        public PlotService(IRealStateUnitOfWork realStateUnitOfWork)
        {
            _realStateUnitOfWork = realStateUnitOfWork;
        }

        public void AddNewPlot(Plot plot)
        {
            if (plot.Block != null)
            {
                var blockname = plot.Block.Name;
                var plotSize = plot.Block.NumPlots;


                for (int i = 0; i < plotSize; i++)
                {
                    var plotEntry = new Plot
                    {
                        BlockId = plot.BlockId,
                        PlotNumber = blockname + (i + 1).ToString("00000"),
                        Status = plot.Status,
                        Price = plot.Price
                    };

                    _realStateUnitOfWork.PlotRepository.Add(plotEntry);
                    _realStateUnitOfWork.Save();

                }
            }
        }

        public void CreateSinglePlot(Plot plot)
        {
            _realStateUnitOfWork.PlotRepository.Add(plot);
            _realStateUnitOfWork.Save();
        }
        public void EditPlot(Plot plot)
        {
            var previousPlot = _realStateUnitOfWork.PlotRepository.GetById(plot.Id);

            if (previousPlot != null)
            {
                previousPlot.PlotNumber = plot.PlotNumber;
                previousPlot.Status = plot.Status;
                previousPlot.Price = plot.Price;
                previousPlot.BlockId = plot.BlockId;
                _realStateUnitOfWork.Save();
            }
        }

        public IEnumerable<Plot> GetAllPlot()
        {
            return _realStateUnitOfWork.PlotRepository.GetAll();
        }

        public Plot GetPlotById(int id)
        {
            return _realStateUnitOfWork.PlotRepository.GetById(id);
        }

        public IEnumerable<Plot> GetPlots(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            return _realStateUnitOfWork.PlotRepository.Get(

                out total,
                out totalFiltered,
                 x => x.PlotNumber.Contains(searchText) || x.Price.ToString().Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }

        public void Remove(int id)
        {
            _realStateUnitOfWork.PlotRepository.Remove(id);
            _realStateUnitOfWork.Save();
        }

        public IEnumerable<Plot> GetPlotsByBlockId(int id)
        {
            return _realStateUnitOfWork.PlotRepository.GetAll().Where(p => p.BlockId == id).ToList();
        }
    }
}
