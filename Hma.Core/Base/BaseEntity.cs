using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Hma.Core.Base
{
	public class BaseEntity
	{
		public BaseEntity()
		{
			this.CreatedDate = DateTime.Now;
			this.IsDeleted = false;
		}

		[Key]
		[ScaffoldColumn(false)]
		public int Id { get; set; }
		[ScaffoldColumn(false)]
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public bool IsDeleted { get; set; }
	}
}
