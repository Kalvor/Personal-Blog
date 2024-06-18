using blog_service.Domain.SeedWork;

namespace blog_service.External.Persistance.Repository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : Entity, IAggregateRoot
    {
        protected BlogDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public GenericRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> GetByIdAsync(uint id, CancellationToken cancellationToken = default)
        {
            var entity = await _context
                .Set<TEntity>()
                .FindAsync(keyValues: [id], cancellationToken:cancellationToken);
            return entity;
        }

        public Task<IQueryable<TEntity>> GetAsync<TResult>(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
