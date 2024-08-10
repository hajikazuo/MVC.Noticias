using Microsoft.AspNetCore.Mvc.Rendering;
using NoticiasMvc.Models;

namespace NoticiasMvc.ViewModels
{
    public class ArticlesResponseViewModel
    {
        public List<Article> Articles { get; set; }
    }
}
