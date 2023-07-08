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
    public class PlotBookingRepository : Repository<PlotBooking>, IPlotBookingRepository
    {
        public PlotBookingRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
