using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
    {
        private readonly StoreContext _storeContext;

        public GenericRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<T> GetByID(int id)
        {
           return await _storeContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIDAsync(ISpecification<T> specification)
        {
           return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetListAsync()
        {
             return await _storeContext.Set<T>().ToListAsync();
        }

          public async Task<IReadOnlyCollection<T>> GetListAsync(ISpecification<T> spec)
        {
             return await ApplySpecification(spec).ToListAsync();
        }

         private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_storeContext.Set<T>().AsQueryable(), spec);
        }
    }
}