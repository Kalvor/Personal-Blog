using blog_service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace blog_service.External.Persistance.EntityTypeConfigurations
{
    internal class ArticleConfiguration : EntityConfiguration<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            base.Configure(builder);
        }
    }
}
