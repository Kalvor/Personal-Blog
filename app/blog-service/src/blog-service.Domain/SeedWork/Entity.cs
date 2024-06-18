namespace blog_service.Domain.SeedWork
{
    public abstract class Entity<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
    }
}
