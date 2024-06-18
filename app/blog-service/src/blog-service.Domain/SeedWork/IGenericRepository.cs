using blog_service.Domain.Entities;
using blog_service.Domain.SeedWork;

namespace blog_service.Domain.SeedWork
{
    public interface IGenericRepository<TEntity>
        where TEntity : Entity, IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        Task<Article> GetSpecificAsync(Guid id);
    }
}
