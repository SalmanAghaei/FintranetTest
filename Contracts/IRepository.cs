namespace Contracts
{
    public interface IRepository<TEntity, Tkey> : IScopedLifeTime where TEntity : Entity
    {
        TEntity Get(Tkey id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        void SaveChanges();
    }
}
