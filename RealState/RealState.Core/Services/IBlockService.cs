using RealState.Core.Entity;
using System.Collections.Generic;

namespace RealState.Core.Services
{
    public interface IBlockService
    {
        Block AddNewBlock(Block block);
        IEnumerable<Block> GetAllBlock();
        Block GetBlockById(int id);
        void EditBlock(Block block);
        void Remove(int id);
        IEnumerable<Block> GetBlocks(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered);
    }
}