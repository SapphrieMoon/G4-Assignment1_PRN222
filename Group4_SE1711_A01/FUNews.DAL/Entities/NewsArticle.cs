using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNews.DAL.Entities
{
    public class NewsArticle
    {
        public int NewsArticleID { get; set; }
        public string NewsTitle { get; set; }
        public string Headline { get; set; }
        public DateTime CreatedDate { get; set; }
        public string NewsContent { get; set; }
        public string NewsSource { get; set; }
        public int CategoryID { get; set; }
        public bool NewsStatus { get; set; }
        public int CreatedByID { get; set; }
        public int? UpdatedByID { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // Navigation
        public Category Category { get; set; }
        public SystemAccount CreatedBy { get; set; }
        public SystemAccount UpdatedBy { get; set; }
        public ICollection<NewsTag> NewsTags { get; set; }
    }
}
