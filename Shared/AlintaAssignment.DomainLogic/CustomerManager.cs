using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlintaAssignment.Domain.Models;
using AlintaAssignment.Store;

namespace AlintaAssignment.DomainLogic
{
    public class CustomerManager : ICustomerManager
    {
        public CustomerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private readonly IUnitOfWork _unitOfWork;

        public async Task<IEnumerable<Customer>> FindCustomerByNameAsync(string name)
        {
            var customers = await _unitOfWork.CustomerRepository.FindByConditionAsync(c => c.FirstName.ToUpper().Equals(name.ToUpper()) || c.LastName.ToUpper().Equals(name.ToUpper()));
            //var customers = await _unitOfWork.CustomerRepository.FindAllAsync();
            //customers.Where(x => x.FirstName == name).ToList();
            return customers;
        }
        public async Task<Guid> AddCustomerAsync(Customer customer)
        {
            _unitOfWork.CustomerRepository.Create(customer);
            var ids = await _unitOfWork.SaveAsync();
            return ids.First();
        }

        public async Task DeleteCustomer(string id)
        {
            await _unitOfWork.CustomerRepository.Delete(new Guid(id));
            await _unitOfWork.SaveAsync();
        }

        public async Task<Guid> EditCustomerAsync(Customer customer)
        {
            _unitOfWork.CustomerRepository.Update(customer);
            var ids = await _unitOfWork.SaveAsync();
            return ids.First();
        }
    }
}
