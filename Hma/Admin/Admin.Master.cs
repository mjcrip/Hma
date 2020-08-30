using Hma.Core.Entities;
using Hma.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hma.Admin
{
	public partial class Admin : System.Web.UI.MasterPage
	{
		public BloggingService _bloggingService { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		public List<Article> GetArticles()
		{
			var t = _bloggingService.GetArticles();
			return t;
		}
	}
}