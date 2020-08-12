using Hma.Core.Entities;
using Hma.Core.Interfaces;
using Hma.Infra.Shared;
using System.Data.Entity;

namespace Hma.Infra.Domains.BloggingContext
{
	public class BloggingContext : EntityContext
	{
		public BloggingContext() : base(ContextNames.Blogging)
		{

		}
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("Blogging");
		}

		public DbSet<Article> Articles { get; set; }
		public DbSet<Author> Author { get; set; }
		public DbSet<Person> People { get; set; }
		public DbSet<Contact> Contacts { get; set; }
	}
}
