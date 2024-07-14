namespace blog_service.Domain.SeedWork
{
    public interface IGenericRepository<TEntity>
        where TEntity : Entity, IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        Task<TEntity?> GetByIdAsync(uint id, CancellationToken cancellationToken = default);
        IQueryable<TEntity> Get<TResult>();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
