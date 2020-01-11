using AlintaAssignment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlintaAssignment.Data
{
    public interface ICustomerDbContext : IDisposable
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<IEnumerable<Guid>> GetSaveChangesAsync();
    }
}
