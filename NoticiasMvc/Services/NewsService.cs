using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NoticiasMvc.Models;
using NoticiasMvc.Services.Interfaces;
using NoticiasMvc.Settings;
using NoticiasMvc.ViewModels;

namespace NoticiasMvc.Services
{
    public class NewsService : INewsService
    {
        private readonly string _apiKey;

        public NewsService(IOptions<NewsApiSettings> apiSettings)
        {
            _apiKey = apiSettings.Value.ChaveApi;
        }

        public async Task<List<Article>> GetNewsAsync()
        {
           
            var apiUrl = "https://newsapi.org/v2/everything?q=technology";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("x-api-key", _apiKey);
                httpClient.DefaultRequestHeaders.Add("User-Agent", "NoticiasMVC");

                using (var response = await httpClient.GetAsync(apiUrl))
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    var articlesResponse = JsonConvert.DeserializeObject<ArticlesResponseViewModel>(responseData);

                    return articlesResponse.Articles;
                }
            }
        }

    }
}
