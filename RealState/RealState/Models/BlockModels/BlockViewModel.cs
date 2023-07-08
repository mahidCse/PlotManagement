using Autofac;
using Newtonsoft.Json.Linq;
using RealState.Core.Entity;
using RealState.Core.Services;
using RealState.Models.CustomerModels;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RealState.Models.BlockModels
{
    public class BlockViewModel
    {
        private IBlockService _blockService;
        private IPlotService _plotService;

        public BlockViewModel()
        {
            _blockService = Startup.AutofacContainer.Resolve<IBlockService>();
            _plotService = Startup.AutofacContainer.Resolve<IPlotService>();
        }


        public object GetBlocks(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _blockService.GetBlocks(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                out total,
                out totalFiltered);


            var blockModelList = new List<BlockModel>();

            foreach (var block in records)
            {
                var PlotByBlockId = _plotService.GetPlotsByBlockId(block.Id);

                var numOfPlots = PlotByBlockId.Count();
                var soldPlots = PlotByBlockId.Where(x => x.Status == 0).Count();

                blockModelList.Add(new BlockModel
                {
                    Id = block.Id,
                    Name = block.Name,
                    City = block.City,
                    NumPlots = numOfPlots,
                    NumAvailablePlots = numOfPlots - soldPlots,
                    NumSoldPlots = soldPlots
                });
            }

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in blockModelList
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.Name,
                                record.City,
                                record.NumPlots.ToString(),
                                record.NumAvailablePlots.ToString(),
                                record.NumSoldPlots.ToString(),
                                record.Description

                        }
                    ).ToArray()

            };
        }


        public IEnumerable<BlockModel> GetBlocks()
        {
            var blocks =  _blockService.GetAllBlock();

            var blockList = new List<BlockModel>();
            foreach (var block in blocks)
            {
                blockList.Add(new BlockModel
                {
                    Id = block.Id,
                    Name = block.Name,
                });
            }

            return blockList;
        }

        public BlockModel Load(int id)
        {
            var block = _blockService.GetBlockById(id);

            return new BlockModel
            {
                Id = block.Id,
                Name = block.Name,
                City = block.City,
                NumPlots = block.NumPlots,
                NumAvailablePlots = block.NumAvailablePlots,
                NumSoldPlots = block.NumSoldPlots
            };
        }
    }
}
