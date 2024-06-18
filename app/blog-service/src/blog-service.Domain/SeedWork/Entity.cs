namespace blog_service.Domain.SeedWork
{
    public abstract class Entity
    {
        public uint Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
    }
}
