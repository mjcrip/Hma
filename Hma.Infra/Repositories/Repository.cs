using Hma.Core.Interfaces;
using Hma.Infra.Shared;
using System.Data.Entity;
using System.Linq;

namespace Hma.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityContext
    {
        private readonly EntityContext _dbContext;

        public Repository(EntityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> AsQueryable()
        {
            return this.Entities.AsQueryable();
        }

        public void Delete(int id)
        {
            var entity = Find(id);
            this.Entities.Remove(entity);
        }

        public T Find(params object[] keyValues)
        {
            return this.Entities.Find(keyValues);
        }

        public void Insert(T entity)
        {
            this.Entities.Add(entity);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        private DbSet<T> Entities
        {
            get
            {
                return _dbContext.Set<T>();
            }
        }
    }
}
