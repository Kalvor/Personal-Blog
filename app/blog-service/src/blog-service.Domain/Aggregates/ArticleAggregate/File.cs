using blog_service.Domain.SeedWork;

namespace blog_service.Domain.Aggregates.ArticleAggregate
{
    public sealed class File(string storageUrl) : ValueObject
    {
        public string StorageUrl { get; } = storageUrl;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StorageUrl;
        }
    }
}
