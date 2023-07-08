using RealState.Core.Entity;
using System.Collections.Generic;

namespace RealState.Core.Services
{
    public interface ICustomerService
    {
        void AddNewCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomer();
        Customer GetCustomerById(int id);
        void EditCustomer(Customer customer);
        void Remove(int id);
        IEnumerable<Customer> GetCustomers(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered);
    }
}