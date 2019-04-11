//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace EFCORE.Models
//{
//    public partial class BloggingContextContext : DbContext
//    {
//        public BloggingContextContext()
//        {
//        }

//        public BloggingContextContext(DbContextOptions<BloggingContextContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<Blog> Blogs { get; set; }
//        public virtual DbSet<Comment> Comments { get; set; }
//        public DbQuery<BlogCommentsView> AuthorArticleCounts { get; set; }
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;  Database = BloggingContext; Trusted_Connection = True;  MultipleActiveResultSets=True;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Blog>(entity =>
//            {
//                entity.Property(e => e.BlogName)
//                    .HasMaxLength(100)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<Comment>(entity =>
//            {
//                entity.Property(e => e.Id).ValueGeneratedNever();

//                entity.Property(e => e.Comment1)
//                    .HasColumnName("Comment")
//                    .HasMaxLength(100)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.Blog)
//                    .WithMany(p => p.Comments)
//                    .HasForeignKey(d => d.BlogId)
//                    .HasConstraintName("FK__Comment__BlogId__239E4DCF");
//            });
//        }
//    }
//}
