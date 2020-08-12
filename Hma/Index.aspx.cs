using Hma.Core.Entities;
using Hma.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Hma
{
    public partial class Index : System.Web.UI.Page
	{
        public const string BaseDirectoryName = "ftp://hindimeanswer.com/httpdocs"; 
        public BloggingService _bloggingService { get; set; }
		public HtmlGeneratorService _generatorService { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
            var article = new Article()
            {
                Author = new Author() {
                Person = new Person() {
                    FirstName= "Manish",
                    LastName = "Joshi",
                    Organization = "Hma"
                },
                Description ="Freelance Writer"
                },
                Title = "Demo Title",
                Description = "Demo Description"
            };
            //_bloggingService.InsertArticle(article);
            var t = _bloggingService.GetArticles();
            CreateFileUsingFtp(t);
            _bloggingService.SaveChanges();
		}

		public void CreateFileUsingFtp(List<Article> articles)
		{
            try
            {
                foreach (var article in articles)
                {
                    var byteArray = _generatorService.CreateSinglePageHtml(article);
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(BaseDirectoryName + article.StorePath);
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.ContentLength = byteArray.Length;
                    request.UsePassive = true;
                    request.KeepAlive = true;
                    request.UseBinary = true;
                    request.EnableSsl = false;
                    request.Credentials = new NetworkCredential("hindi86w", "8poeI61_");
                    try
                    {
                        using (Stream requestStream = request.GetRequestStream())
                        {
                            requestStream.Write(byteArray, 0, byteArray.Length);
                            requestStream.Close();
                        }
                    }
                    catch(Exception e)
                    {
                        CreateDirectory(article.StorePath);
                        try
                        {
                            using (Stream requestStream = request.GetRequestStream())
                            {
                                requestStream.Write(byteArray, 0, byteArray.Length);
                                requestStream.Close();
                                article.IsCreated = true;
                            }
                        }
                        catch(Exception t)
                        {
                            //Cannot make file
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }
        }
        /// <summary>
        /// Base directory is httpdocs  
        /// </summary>
        /// <param name="directoryPath">Directory path after base directory</param>
        public void CreateDirectory(string directoryPath)
        {
            var folders = directoryPath.Split('/').ToList();
            folders.RemoveAt(folders.Count - 1);
            string done = BaseDirectoryName;
            foreach (var folder in folders)
            {
                done = done + $"/{folder}";
                //Create FTP Request.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(done);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.KeepAlive = true;
                //Enter FTP Server credentials.
                request.Credentials = new NetworkCredential("hindi86w", "8poeI61_");
                try {
                    using (var resp = (FtpWebResponse)request.GetResponse())
                    {
                        Console.WriteLine(resp.StatusCode);
                    }
                }
                catch(Exception e)
                {
                    //Folder already exists
                }
            }
        }
	}
}