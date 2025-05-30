using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNews.DAL.Entities
{
    public class Tag
    {
        public int TagID { get; set; }
        public string TagName { get; set; }
        public string Note { get; set; }

        // Navigation
        public ICollection<NewsTag> NewsTags { get; set; }
    }
}
