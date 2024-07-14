using blog_service.Domain.Aggregates.ArticleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace blog_service.External.Persistance.EntityTypeConfigurations
{
    internal sealed class CommentConfiguration : EntityConfiguration<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasMany(c => c.Responses)
                .WithOne()
                .HasForeignKey("ParentCommentId")
                .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
