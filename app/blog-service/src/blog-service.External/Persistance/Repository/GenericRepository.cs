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

        public IQueryable<TEntity> Get<TResult>()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }
    }
}
