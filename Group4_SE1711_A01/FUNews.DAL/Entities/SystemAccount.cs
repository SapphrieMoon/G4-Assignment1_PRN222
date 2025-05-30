using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNews.DAL.Entities
{
    public class SystemAccount
    {
        [Key] // <-- Gắn thuộc tính này nếu EF không tự nhận diện
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public string AccountEmail { get; set; }
        public string AccountRole { get; set; }  // Admin, Staff, Lecturer
        public string AccountPassword { get; set; }

        // Navigation
        public ICollection<NewsArticle> CreatedArticles { get; set; }
        public ICollection<NewsArticle> UpdatedArticles { get; set; }
    }
}
