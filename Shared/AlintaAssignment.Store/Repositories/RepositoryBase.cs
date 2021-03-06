﻿using System;
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
            var task = Task.Run(() =>
            {
                var query = RepositoryContext.Set<T>().Where(expression);
                typeof(T).GetProperties().ToList().ForEach(p => query.Include(p.Name));
                return query.ToList();
            });

            return await task;
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

        public async Task DeleteAsync(Guid id)
        {
            var entity = await FindByConditionAsync(e => e.Id == id);
            if (!entity.Any())
                throw new Exception("No Matching Entity found");

            RepositoryContext.Set<T>().Remove(entity.First());
        }
    }
}
