using Hma.Core.Base;
using Hma.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hma.Core.Services
{
    public abstract class BaseService
    {
        private readonly IEnumerable<IEntityContextRepository<IEntityContext>> _entityContextRepositories;

        public BaseService(
            IEnumerable<IEntityContextRepository<IEntityContext>> entityContextRepositories)
        {
            _entityContextRepositories = entityContextRepositories;
        }

        protected IEnumerable<IEntityContextRepository<IEntityContext>> Repositories
        {
            get => _entityContextRepositories;
        }


        public IEntityContextRepository<IEntityContext> GetContextualRepository(ContextNames name)
        {
            return _entityContextRepositories.Single(e => e.Name == name);
        }

        public IQueryable<TEntity> GetQueryable<TEntity>(ContextNames contextName, params string[] includes)
            where TEntity : BaseEntity

        {
            return GetContextualRepository(contextName).GetQueryable<TEntity>(includes);
        }
        protected int Save(ContextNames name)
        {
            return GetContextualRepository(name).SaveChanges();
        }
    }
}
