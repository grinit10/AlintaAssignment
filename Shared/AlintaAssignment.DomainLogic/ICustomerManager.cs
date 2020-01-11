using AlintaAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlintaAssignment.DomainLogic
{
    public interface ICustomerManager
    {
        Task<IEnumerable<Customer>> FindCustomerByNameAsync(string name);
        Task<Guid> AddCustomerAsync(Customer customer);
        Task<Guid> EditCustomerAsync(Customer customer);
        Task DeleteCustomer(string id);
    }
}
