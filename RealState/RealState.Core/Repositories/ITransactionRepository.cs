using RealState.Core.Entity;
using RealState.Data;
using System.Collections.Generic;

namespace RealState.Core.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IList<Transaction> GetTransactionsBySP();
    }
}