using RealState.Core.Entity;
using RealState.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Services
{
    public class AccountService : IAccountService
    {
        private IRealStateUnitOfWork _realStateUnitOfWork;
        public AccountService(IRealStateUnitOfWork realStateUnitOfWork)
        {
            _realStateUnitOfWork = realStateUnitOfWork;
        }

        public void AddNewAccount(Account account)
        {
            _realStateUnitOfWork.AccountRepository.Add(account);
            _realStateUnitOfWork.Save();
        }

        public void EditAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountById(int id)
        {
            return _realStateUnitOfWork.AccountRepository.GetById(id);
        }

        public IEnumerable<Account> GetAccounts(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            return _realStateUnitOfWork.AccountRepository.Get(

                out total,
                out totalFiltered,
                 x => x.Name.Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }

        public IEnumerable<Account> GetAllAccount()
        {
            return _realStateUnitOfWork.AccountRepository.GetAll();
        }

        public void Remove(int id)
        {
            _realStateUnitOfWork.AccountRepository.Remove(id);
            _realStateUnitOfWork.Save();
        }
    }
}
