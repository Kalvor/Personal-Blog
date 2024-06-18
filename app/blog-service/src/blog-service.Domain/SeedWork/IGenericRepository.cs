namespace blog_service.Domain.SeedWork
{
    public interface IGenericRepository<TEntity>
        where TEntity : Entity, IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        Task<TEntity?> GetByIdAsync(uint id, CancellationToken cancellationToken = default);
        Task<IQueryable<TEntity>> GetAsync<TResult>(CancellationToken cancellationToken = default);
    }
}
