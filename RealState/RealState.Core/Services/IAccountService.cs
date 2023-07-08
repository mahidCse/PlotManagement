using RealState.Core.Entity;
using System.Collections.Generic;

namespace RealState.Core.Services
{
    public interface IAccountService
    {
        void AddNewAccount(Account block);
        IEnumerable<Account> GetAllAccount();
        Account GetAccountById(int id);
        void EditAccount(Account block);
        void Remove(int id);
        IEnumerable<Account> GetAccounts(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered);
    }
}