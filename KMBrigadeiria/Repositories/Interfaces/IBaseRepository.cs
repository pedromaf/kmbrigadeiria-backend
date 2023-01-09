using KMBrigadeiria.Models.Entities;

namespace KMBrigadeiria.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public TEntity Get(long? id);
        public IEnumerable<TEntity> GetAll();
    }
}
