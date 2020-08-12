using Hma.Core.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hma.Core.Entities
{
	public class Author : BaseEntity
	{
		public int PersonId { get; set; }
		[ForeignKey("PersonId")]
		public Person Person { get; set; }
		public string Description { get; set; }
	}
}