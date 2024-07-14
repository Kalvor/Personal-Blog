using blog_service.Domain.Aggregates.UserAggregate;
using blog_service.Domain.SeedWork;

namespace blog_service.Domain.Aggregates.ArticleAggregate
{
    public sealed class Article : Entity, IAggregateRoot
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string RawContent { get; private set; }
        public User Author { get; }


        private readonly List<Comment> _comments;
        public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

        private readonly List<File> _files;
        public IReadOnlyCollection<File> Files => _files.AsReadOnly();
    }
}



