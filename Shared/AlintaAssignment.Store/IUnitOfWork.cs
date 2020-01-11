using AlintaAssignment.Domain.Models;
using AlintaAssignment.Repositories.Store;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlintaAssignment.Store
{
    public interface IUnitOfWork
    {
        IRepositoryBase<Customer> CustomerRepository { get; }
        Task<IEnumerable<Guid>> SaveAsync();
    }
}
