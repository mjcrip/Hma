using Hma.Core.Entities;
using Hma.Core.Services;
using System;

namespace Hma.Admin.Articles
{
	public partial class Create : System.Web.UI.Page
	{
		public BloggingService _bloggingService { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		public string CreateArticle(Article article)
		{
			try
			{
				_bloggingService.InsertArticle(article);
				return $"Article saved successfully having Id={article.Id}";
			}
			catch(Exception e)
			{
				return e.Message;
			}
		}
	}
}