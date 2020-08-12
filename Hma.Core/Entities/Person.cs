using Hma.Core.Base;
using System.Collections.Generic;

namespace Hma.Core.Entities
{
	public class Person : BaseEntity
	{
		public List<Contact> Contacts { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Organization { get; set; }
	}
}