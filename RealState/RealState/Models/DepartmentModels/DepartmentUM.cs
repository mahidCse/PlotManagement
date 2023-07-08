using Autofac;
using RealState.Core.Entity;
using RealState.Core.Services;
using RealState.Models.CategoryModels;

namespace RealState.Models.DepartmentModels
{
    public class DepartmentUM
    {
        private IAccountService _accountService;

        public DepartmentUM()
        {
          _accountService = Startup.AutofacContainer.Resolve<IAccountService>();
        }

        public void AddNewAccount(DepartmentModel account)
        {
          _accountService.AddNewAccount(new Account
            {
                Name = account.Name
            });
        }

        public void UpdateCategory(DepartmentModel account)
        {

          _accountService.EditAccount(new Account
          {
                Id = account.Id,
                Name = account.Name,
            });
        }


        public void DeleteAccount(int id)
        {
          _accountService.Remove(id);

        }
    }
}
