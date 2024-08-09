using NoticiasMvc.Models;

namespace NoticiasMvc.Services.Interfaces
{
    public interface INewsService
    {
        Task<List<Article>> GetNewsAsync(Category? category);
    }
}
