using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNews.DAL.Entities
{
    public class NewsTag
    {
        public int NewsArticleID { get; set; }
        public int TagID { get; set; }

        // Navigation
        public NewsArticle NewsArticle { get; set; }
        public Tag Tag { get; set; }
    }
}
