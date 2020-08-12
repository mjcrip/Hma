using Hma.Core.Base;
using System.Collections.Generic;
using System.Linq;

namespace Hma.Core.Interfaces
{
    public interface IEntityContextRepository<out TContext> where TContext : IEntityContext
    {
        IQueryable<TEntity> GetQueryable<TEntity>(List<string> includes = null) where TEntity : BaseEntity;
        IQueryable<TEntity> GetQueryable<TEntity>(params string[] includes) where TEntity : BaseEntity;
        int SaveChanges();
        IQueryable<TEntity> GetNoTrackingQueryable<TEntity>(List<string> includes = null) where TEntity : BaseEntity;
        IQueryable<TEntity> GetNoTrackingQueryableWithDeleted<TEntity>(List<string> includes = null) where TEntity : BaseEntity;
        ContextNames Name { get; }
        void ExecuteSqlQuery(string sql, params string[] parameters);
        void Insert<TEntity>(TEntity entity) where TEntity : BaseEntity;
    }
}
