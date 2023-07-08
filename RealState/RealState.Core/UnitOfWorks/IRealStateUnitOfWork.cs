using RealState.Core.Context;
using RealState.Core.Repositories;
using RealState.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.UnitOfWorks
{
    public interface IRealStateUnitOfWork : IUnitOfWork<RealStateContext>
    {
        ICustomerRepository CustomerRepository { get; set; }
        IBlockRepository BlockRepository { get; set; }
        IPlotRepository PlotRepository { get; set; }
        IPlotBookingRepository PlotBookingRepository { get; set; }
        IAccountRepository AccountRepository { get; set; }
        ICategoryRepository CategoryRepository { get; set; }
        ITransactionRepository TransactionRepository { get; set; }

    }
}
