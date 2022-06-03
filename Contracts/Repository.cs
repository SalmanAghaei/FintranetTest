using Microsoft.EntityFrameworkCore;

namespace Contracts
{
    public class Repository<TEntity, TKey, TDbContext> : IRepository<TEntity, TKey>
        where TEntity : Entity
        where TDbContext : DbContext
    {
        protected readonly TDbContext _dbContext;
        public Repository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(TEntity entity)
        {
            _dbContext.Remove(entity);
        }
        public TEntity Get(TKey id) =>
            _dbContext.Set<TEntity>().Find(id);

        public void Insert(TEntity entity)
        {
            _dbContext.Add(entity);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Update(entity);
        }

    }
}
