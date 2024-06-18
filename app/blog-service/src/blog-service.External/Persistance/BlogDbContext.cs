using blog_service.Domain.Entities;
using blog_service.Domain.SeedWork;
using blog_service.External.Persistance.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace blog_service.External.Persistance
{
    public sealed class BlogDbContext : DbContext, IUnitOfWork
    {
        public BlogDbContext() { }
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
