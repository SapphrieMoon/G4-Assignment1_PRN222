using FUNews.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FUNews.DAL.Database // <-- ✅ Đổi tên namespace này
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<SystemAccount> SystemAccounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<NewsArticle> NewsArticles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NewsTag> NewsTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NewsTag>()
                .HasKey(nt => new { nt.NewsArticleID, nt.TagID });

            modelBuilder.Entity<NewsTag>()
                .HasOne(nt => nt.NewsArticle)
                .WithMany(na => na.NewsTags)
                .HasForeignKey(nt => nt.NewsArticleID);

            modelBuilder.Entity<NewsTag>()
                .HasOne(nt => nt.Tag)
                .WithMany(t => t.NewsTags)
                .HasForeignKey(nt => nt.TagID);

            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NewsArticle>()
                .HasOne(n => n.CreatedBy)
                .WithMany(a => a.CreatedArticles)
                .HasForeignKey(n => n.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NewsArticle>()
                .HasOne(n => n.UpdatedBy)
                .WithMany(a => a.UpdatedArticles)
                .HasForeignKey(n => n.UpdatedByID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
