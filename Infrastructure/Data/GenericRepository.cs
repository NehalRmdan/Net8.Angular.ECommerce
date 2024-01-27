using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
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

        public async Task<IReadOnlyCollection<T>> GetListAsync()
        {
             return await _storeContext.Set<T>().ToListAsync();
        }
    }
}