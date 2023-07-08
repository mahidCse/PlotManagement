using Microsoft.EntityFrameworkCore;
using RealState.Core.Entity;
using RealState.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Repositories
{
    public class BlockRepository : Repository<Block>, IBlockRepository
    {
        public BlockRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
