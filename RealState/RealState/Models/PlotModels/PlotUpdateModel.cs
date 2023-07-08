using Autofac;
using RealState.Core.Entity;
using RealState.Core.Services;
using System.Linq;

namespace RealState.Models.PlotModels
{
    public class PlotUpdateModel
    {
        private IPlotService _plotService;
        private IBlockService _blockService;

        public PlotUpdateModel()
        {
            _plotService = Startup.AutofacContainer.Resolve<IPlotService>();
            _blockService = Startup.AutofacContainer.Resolve<IBlockService>();
        }

        public void CreateNewPlot(PlotModel plotModel)
        {
            var plotCount = _plotService.GetPlotsByBlockId(plotModel.BlockId).Count();
            var block = _blockService.GetBlockById(plotModel.BlockId);

            _plotService.CreateSinglePlot(new Plot
            {
                BlockId = plotModel.BlockId,
                PlotNumber = block.Name + (plotCount + 1).ToString("00000"),
                Price = plotModel.Price,
                Status = 1,
            });
        }
    }
}
