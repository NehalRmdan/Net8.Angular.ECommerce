using core.Entities;

namespace core.Interfaces
{
    public interface IUnitOfWork
    {
        public Task<int> Complete();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity ;

    }
}