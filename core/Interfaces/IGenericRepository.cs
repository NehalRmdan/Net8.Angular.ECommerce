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

        public Task<IReadOnlyList<T>> GetListAsync();
        
        public Task<IReadOnlyList<T>> GetListAsync(ISpecification<T> specification);

        public Task<int> GetCountAsync(ISpecification<T> specification);

        public Task<T> GetByID(int id);

        public Task<T> GetByIDAsync(ISpecification<T> specification);

        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}