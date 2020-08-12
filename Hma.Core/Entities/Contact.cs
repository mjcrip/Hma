using Hma.Core.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hma.Core.Entities
{
	public class Contact : BaseEntity
	{
		public int PersonId { get; set; }
		[ForeignKey("PersonId")]
		public Person Person { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string City { get; set; }
		public string Zip { get; set; }
	}
}