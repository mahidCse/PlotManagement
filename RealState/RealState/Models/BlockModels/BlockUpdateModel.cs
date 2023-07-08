using Autofac;
using RealState.Core.Entity;
using RealState.Core.Services;
using RealState.Models.CustomerModels;
using RealState.Models.PlotModels;
using System;

namespace RealState.Models.BlockModels
{
    public class BlockUpdateModel
    {
        private IBlockService _blockService;
        private IPlotService _plotService;

        public BlockUpdateModel()
        {
            _blockService = Startup.AutofacContainer.Resolve<IBlockService>();
            _plotService = Startup.AutofacContainer.Resolve<IPlotService>();
        }

        public void AddNewBlock(BlockModel blockModel)
        {
            var block = _blockService.AddNewBlock(new Block
            {
                Name = blockModel.Name,
                Description = blockModel.Description,
                City = blockModel.City,
                NumPlots = blockModel.NumPlots,
                NumAvailablePlots = blockModel.NumPlots,
                NumSoldPlots = 0
            });

            CreatePlots(block, blockModel.PlotPrice);
        }

        private void CreatePlots(Block block, decimal plotPrice)
        {

            _plotService.AddNewPlot(new Plot
            {
                BlockId = block.Id,
                Price = plotPrice,
                Block = block,
                Status = 1
            }) ;
        }


        public void UpdateBlock(BlockModel block)
        {
            _blockService.EditBlock(new Block
            {
                Name = block.Name,
                Description = block.Description,
                City = block.City,
                NumPlots = block.NumPlots,
                NumAvailablePlots = block.NumAvailablePlots,
                NumSoldPlots = block.NumSoldPlots
            });
        }

        public void DeleteBlock(int id)
        {
            _blockService.Remove(id);
        }
    }
}
