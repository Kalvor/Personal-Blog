using blog_service.Domain.Entities;
using blog_service.Domain.SeedWork;

namespace blog_service.Domain.SeedWork
{
    public interface IGenericRepository<TEntity,TKey>
        where TKey : IEquatable<TKey>
        where TEntity : Entity<TKey>, IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
    }
}
