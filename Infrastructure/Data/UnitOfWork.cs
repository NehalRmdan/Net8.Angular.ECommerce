

using System.Collections;
using core.Entities;
using core.Interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private Hashtable _repositories;
        private readonly StoreContext _storeContext;

        public UnitOfWork(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public Task<int> Complete()
        {
            return _storeContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _storeContext.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) {
                _repositories = new Hashtable();
            }
            string type= typeof(TEntity).Name;

            if(!_repositories.ContainsKey(type)) {

                var repoType= typeof(GenericRepository<>);
                var repo= Activator.CreateInstance(repoType.MakeGenericType(typeof(TEntity)), _storeContext);
                _repositories.Add(type, repo);
            }

           
            return (IGenericRepository<TEntity>) _repositories[type];
        }
    }
}