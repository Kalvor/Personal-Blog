using blog_service.Domain.Aggregates.ArticleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace blog_service.External.Persistance.EntityTypeConfigurations
{
    internal sealed class ArticleConfiguration : EntityConfiguration<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasOne(c => c.Author)
                .WithMany()
                .HasForeignKey("AuthorId")
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c=>c.Comments)
                .WithOne()
                .HasForeignKey("ArticleId");

            builder.OwnsMany(c => c.Files, a => {
                a.WithOwner().HasForeignKey("ArticleId");
                a.Property<int>("Id");
                a.Property(c => c.StorageUrl);
                a.HasKey("Id");
            });

            base.Configure(builder);
        }
    }
}
