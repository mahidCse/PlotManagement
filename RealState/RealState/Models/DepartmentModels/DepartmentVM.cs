using Autofac;
using RealState.Core.Services;
using RealState.Models.DepartmentModels;
using System.Collections.Generic;
using System.Linq;

namespace RealState.Models.DepartmentModels
{
    public class DepartmentVM
    {
        private IAccountService _accountService;

        public DepartmentVM()
        {
            _accountService = Startup.AutofacContainer.Resolve<IAccountService>();
        }
        public object GetAccounts(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _accountService.GetAccounts(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                out total,
                out totalFiltered);

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.Name
                        }
                    ).ToArray()

            };
        }

        public DepartmentModel Load(int id)
        {
            var account = _accountService.GetAccountById(id);

            return new DepartmentModel
            {
                Id = account.Id,
                Name = account.Name
            };
        }

        public IList<DepartmentModel> FindAllaccount()
        {
            var accounts = _accountService.GetAllAccount();

            var accountList = new List<DepartmentModel>();

            foreach (var account in accounts)
            {
                accountList.Add(new DepartmentModel
                {
                    Id = account.Id,
                    Name = account.Name
                });
            }

            return accountList;
        }
    }
}
