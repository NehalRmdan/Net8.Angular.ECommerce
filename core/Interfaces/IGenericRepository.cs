using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;

namespace core.Interfaces
{
    public interface IGenericRepository<T>  
    {
        public Task<IReadOnlyCollection<T>> GetListAsync();
        
        public Task<T> GetByID(int id);
    }
}