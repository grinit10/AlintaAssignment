using System;
using System.Linq;
using AlintaAssignment.Data;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AlintaAssignment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AlintaAssignment.Repositories.Store
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseModel
    {
        private ICustomerDbContext RepositoryContext { get; set; }

        public RepositoryBase(ICustomerDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await RepositoryContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            var query = RepositoryContext.Set<T>().Where(expression);
            typeof(T).GetProperties().ToList().ForEach(p => query.Include(p.Name));
            return await query.ToListAsync();
        }

        public T Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
            return entity;
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await FindByConditionAsync(e => e.Id == id);
            if (entity == null)
                throw new Exception("No Matching Customer");

            RepositoryContext.Set<T>().Remove(entity.First());
        }
    }
}
