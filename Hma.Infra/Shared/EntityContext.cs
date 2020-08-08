using Hma.Core.Interfaces;
using System.Data.Entity;

namespace Hma.Infra.Shared
{
	public class EntityContext : DbContext, IEntityContext
	{
		public EntityContext(ContextNames name) : base("Blog")
		{
			Name = name;
		}

		public ContextNames Name { get; }
	}
}
