using Hma.Core.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hma.Core.Entities
{
    public class Article : BaseEntity
    {
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string SectionName { get; set; }
        public string MainImage { get; set; }
        public string ParagraphContent1 { get; set; }
        public string BlockQuote { get; set; }
        public string ListItemsCsv { get; set; }
        public string ParagraphContent2 { get; set; }
        public string ParagraphContent3 { get; set; }
        public string ParagraphContent4 { get; set; }
        public string ParagraphContent5 { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Path with file name (From httpdocs)
        /// </summary>
        public string StorePath { get; set; }
        public bool IsCreated { get; set; }
    }
}
