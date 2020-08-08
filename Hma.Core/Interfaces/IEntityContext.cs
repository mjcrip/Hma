using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hma.Core.Interfaces
{
	public interface IEntityContext
	{
		ContextNames Name { get; }
	}


	public enum ContextNames
	{
		Blogging
	}
}
