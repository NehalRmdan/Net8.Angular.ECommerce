using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Specifications;

namespace core.Interfaces
{
    public interface IGenericRepository<T>  
    {
        public Task<IReadOnlyCollection<T>> GetListAsync();
        
        public Task<IReadOnlyCollection<T>> GetListAsync(ISpecification<T> specification);

        public Task<T> GetByID(int id);

        public Task<T> GetByIDAsync(ISpecification<T> specification);

    }
}