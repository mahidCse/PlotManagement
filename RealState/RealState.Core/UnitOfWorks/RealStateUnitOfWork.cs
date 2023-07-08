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
    public class RealStateUnitOfWork : UnitOfWork<RealStateContext>, IRealStateUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; set; }
        public IBlockRepository BlockRepository { get; set; }
        public IPlotRepository PlotRepository { get; set; }
        public IPlotBookingRepository PlotBookingRepository { get; set; }
        public IAccountRepository AccountRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public ITransactionRepository TransactionRepository  { get; set; }



        public RealStateUnitOfWork(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {
            CustomerRepository = new CustomerRepository(_dbContext);
            BlockRepository = new BlockRepository(_dbContext);
            PlotRepository = new PlotRepository(_dbContext);
            PlotBookingRepository = new PlotBookingRepository(_dbContext);
            AccountRepository = new AccountRepository(_dbContext);
            CategoryRepository = new CategoryRepository(_dbContext);
            TransactionRepository = new TransactionRepository(_dbContext);
        }
    }
}