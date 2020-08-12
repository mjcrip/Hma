using Hma.Core.Entities;
using Hma.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hma.Core.Services
{
	public class BloggingService : BaseService
	{
		private readonly IEntityContextRepository<IEntityContext> _repository;

		public BloggingService(IEnumerable<IEntityContextRepository<IEntityContext>> entityContextRepositories) 
			: base(entityContextRepositories)
		{
			_repository = entityContextRepositories.Single(e => e.Name == ContextNames.Blogging);
		}

		public List<Article> GetArticles()
		{
			var art = _repository.GetQueryable<Article>().ToList();
			return art;
		}

		public void SaveChanges()
		{
			_repository.SaveChanges();
		}

		public void InsertArticle(Article article)
		{
			_repository.Insert<Article>(article);
			_repository.SaveChanges();
		}
	}
}
