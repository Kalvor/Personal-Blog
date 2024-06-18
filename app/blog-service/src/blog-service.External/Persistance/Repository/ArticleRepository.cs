using blog_service.Application.DAL;
using blog_service.Domain.Entities;

namespace blog_service.External.Persistance.Repository
{
    internal sealed class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(BlogDbContext context) : base(context) { }

        public Task<Article> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
