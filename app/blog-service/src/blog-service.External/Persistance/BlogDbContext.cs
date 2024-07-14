using blog_service.Domain.Aggregates.ArticleAggregate;
using blog_service.Domain.SeedWork;
using blog_service.External.Persistance.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace blog_service.External.Persistance
{
    public sealed class BlogDbContext : DbContext, IUnitOfWork
    {
        public BlogDbContext() { }
        public DbSet<Article> Articles { get; set; }
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
