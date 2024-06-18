namespace blog_service.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
