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
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        private DbContext _dbContext;
        private DbSet<Transaction> _transactionDb;
        private string getTransactionSP = "GetAllTransaction";
        public TransactionRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _transactionDb = _dbContext.Set<Transaction>();
        }

        public IList<Transaction> GetTransactionsBySP()
        {
            var allTransaction = _transactionDb.FromSqlRaw($"exec {getTransactionSP}").ToList();
            return allTransaction;
        }
    }
}
