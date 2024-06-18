using blog_service.Domain.SeedWork;

namespace blog_service.Domain.Entities
{
    public sealed class Article : Entity, IAggregateRoot
    {
        public string Title { get; set; }
    }
}
