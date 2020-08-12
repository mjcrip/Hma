using Hma.Core.Entities;
using Hma.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hma.Core.Services
{
	public class HtmlGeneratorService : BaseService
	{
		private readonly IEntityContextRepository<IEntityContext> _repository;

		public HtmlGeneratorService(IEnumerable<IEntityContextRepository<IEntityContext>> entityContextRepositories)
			: base(entityContextRepositories)
		{
			_repository = entityContextRepositories.Single(e => e.Name == ContextNames.Blogging);
		}

		public byte[] CreateSinglePageHtml(Article article)
		{
			var stream = GetStream("SinglePost.html");
			// convert stream to string
			StreamReader reader = new StreamReader(stream);
			string str = reader.ReadToEnd();
			var generatedStr = GenerateSinglePageHtml(str, article);
			byte[] bytes = Encoding.ASCII.GetBytes(generatedStr);
			return bytes;
		}

		public string GenerateSinglePageHtml(string htmlString, Article article)
		{
			htmlString = htmlString.Replace("{Section_Name}", article.SectionName);
			htmlString = htmlString.Replace("{Post_Month}", article.CreatedDate.ToString());
			htmlString = htmlString.Replace("{Post_Date}", article.CreatedDate.ToString());
			htmlString = htmlString.Replace("{Post_Title}", article.Title);
			htmlString = htmlString.Replace("{Image_Source_Element}", article.MainImage);
			htmlString = htmlString.Replace("{Paragraph_Content_1}", article.ParagraphContent1);
			htmlString = htmlString.Replace("{Block_Quote}", article.BlockQuote);
			htmlString = htmlString.Replace("{List_Items}", article.ListItemsCsv);
			htmlString = htmlString.Replace("{Paragraph_Content_2}", article.ParagraphContent2);
			htmlString = htmlString.Replace("{Author_Name}", article?.Author?.Person?.FirstName);
			htmlString = htmlString.Replace("{Author_Detail}", article?.Author?.Description);
			htmlString = htmlString.Replace("{Image_Source_Element}", article.Title);
			htmlString = htmlString.Replace("{Image_Source_Element}", article.Title);
			return htmlString;
		}

		public FileStream GetStream(string fileName)
		{
			var rootFolder = AppDomain.CurrentDomain.BaseDirectory;
			var pathArray = new string[] { rootFolder, "Sections", "Sample", fileName };
			var path = Path.Combine(pathArray);
			if (!File.Exists(path))
				throw new Exception("File not found to get stream");
			var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			return fileStream;
		}

		public void SaveFile(string fileName, byte[] byteArray)
		{
			var t = fileName.Split('\\').ToList();
			t.Remove(t.LastOrDefault());
			var directoryPath = Path.Combine(t.ToArray());
			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(fileName);
				Directory.Delete(fileName);
			}
			File.WriteAllBytes(fileName, byteArray);
		}
	}
}
