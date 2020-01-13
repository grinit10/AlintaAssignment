using AlintaAssignment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlintaAssignment.Data
{
    public class CustomerDbContext : DbContext, ICustomerDbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public async Task<IEnumerable<Guid>> GetSaveChangesAsync()
        {
            var modifiedIds = new List<Guid>();
            var modifiedEntries = ChangeTracker.Entries()
              .Where(x => x.Entity is BaseModel
                  && (x.State == EntityState.Added || x.State == EntityState.Modified))
              .ToList();
            await base.SaveChangesAsync();
            foreach (var entry in modifiedEntries)
            {
                if (!(entry.Entity is BaseModel entity)) continue;
                modifiedIds.Add(entity.Id);
            }
            return modifiedIds;
        }
    }
}
