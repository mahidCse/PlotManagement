using Autofac;
using RealState.Core.Entity;
using RealState.Core.Services;
using System.Collections.Generic;
using static Humanizer.In;

namespace RealState.Models.CustomerModels
{
    public class CustomerUpdateModel
    {

        private ICustomerService _customerService;

        public CustomerUpdateModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
        }

        public void AddNewCustomer(CustomerModel customer)
        {
            _customerService.AddNewCustomer(new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.Phone,
                Address = customer.Adress
            });
        }

        public void UpdateCustomer(CustomerModel customer)
        {

            _customerService.EditCustomer(new Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.Phone,
                Address = customer.Adress
            });
        }


        public void DeleteCustomer(int id)
        {
            _customerService.Remove(id);

        }
    }
}
