using blog_service.Domain.Aggregates.UserAggregate;
using blog_service.Domain.SeedWork;

namespace blog_service.Domain.Aggregates.ArticleAggregate
{
    public sealed class Comment : Entity
    {
        public User Author { get; set; }
        public string Content { get; set; }
        public bool IsContentDeleted { get; set; }


        private readonly List<Comment> _responses;
        public IReadOnlyCollection<Comment> Responses => _responses.AsReadOnly();
    }
}
