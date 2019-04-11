using System.Reflection;
using EFCORE.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCORE
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(string connectionString= "Server=.\\sqlexpress;Database=BloggingContext;Trusted_Connection=True;") : base(GetOptions(connectionString))
        {
        }

        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {

            var assembly = Assembly.GetAssembly(typeof(BloggingContext));
            return new DbContextOptionsBuilder().UseSqlServer(connectionString, x=>x.MigrationsAssembly(assembly.FullName)).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.BlogName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment1)
                    .HasColumnName("Comment")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("FK__Comment__BlogId__239E4DCF");
            });
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public DbQuery<BlogComment> BlogCommentsView { get; set; }
    }
}
