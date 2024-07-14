using blog_service.Domain.SeedWork;

namespace blog_service.Domain.Aggregates.UserAggregate
{
    public sealed class User : Entity, IAggregateRoot
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string NickName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
    }
}
