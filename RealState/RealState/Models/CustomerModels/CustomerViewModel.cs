using Autofac;
using RealState.Core.Entity;
using RealState.Core.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RealState.Models.CustomerModels
{
    public class CustomerViewModel
    {
        private ICustomerService _customerService;

        public CustomerViewModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
        }


        public object GetCustomers(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _customerService.GetCustomers(
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
                                record.Name,
                                record.Email,
                                record.PhoneNumber,
                                record.Address,
                        }
                    ).ToArray()

            };
        }

        public CustomerModel Load(int id)
        {
            var customer = _customerService.GetCustomerById(id);

            return new CustomerModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.PhoneNumber,
                Adress = customer.Address
            };
        }

        public IList<CustomerModel> FindAllCustomer()
        {
            var customers = _customerService.GetAllCustomer();

            var customerList = new List<CustomerModel>();

            foreach (var customer in customers)
            {
                customerList.Add(new CustomerModel
                {
                    Id = customer.Id,
                    Name = customer.Name
                });
            }

            return customerList;
        }
    }
}
