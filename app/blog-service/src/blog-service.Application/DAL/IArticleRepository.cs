using blog_service.Domain.Entities;

namespace blog_service.Application.DAL
{
    public interface IArticleRepository 
    {
        Task<Article> GetByIdAsync(Guid id);
    }
}
