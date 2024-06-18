using blog_service.Application.DAL;
using blog_service.Domain.Entities;
using blog_service.Domain.SeedWork;

namespace blog_service.External.Persistance.Repository
{
    public abstract class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
        where TKey : IEquatable<TKey>
        where TEntity : Entity, IAggregateRoot
    {
        protected BlogDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public GenericRepository(BlogDbContext context)
        {
            _context = context;
        }

        public Task<Article> GetSpecificAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
