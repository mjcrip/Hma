using Hma.Core.Entities;
using Hma.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hma
{
	public partial class Index : System.Web.UI.Page
	{
		public BloggingService _bloggingService { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			var t = _bloggingService.GetArticles();
		}

	}
}