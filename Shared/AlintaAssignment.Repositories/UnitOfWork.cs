using AlintaAssignment.Data;
using AlintaAssignment.Domain.Models;
using AlintaAssignment.Repositories.Store;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlintaAssignment.Store
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICustomerDbContext _repositoryContext;
        public IRepositoryBase<Customer> CustomerRepository { get; }

        public UnitOfWork(IRepositoryBase<Customer> customerRepository, ICustomerDbContext repositoryContext)
        {
            CustomerRepository = customerRepository;
            _repositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<Guid>> SaveAsync()
        {
            return await _repositoryContext.GetSaveChangesAsync();
        }
    }
}
