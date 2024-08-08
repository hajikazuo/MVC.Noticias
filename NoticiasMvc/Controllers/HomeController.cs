using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NoticiasMvc.Models;
using NoticiasMvc.Settings;
using System.Diagnostics;

namespace NoticiasMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _apiKey;
        private readonly string apiUrl = "https://newsapi.org/v2/everything?q=education";
        private readonly ILogger<HomeController> _logger;

        public HomeController(IOptions<NewsApiSettings> apiSettings, ILogger<HomeController> logger)
        {
            _apiKey = apiSettings.Value.ChaveApi;
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("x-api-key", _apiKey);
                httpClient.DefaultRequestHeaders.Add("User-Agent", "NoticiasMVC");

                using (var response = await httpClient.GetAsync(apiUrl))
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    var articlesResponse = JsonConvert.DeserializeObject<ArticlesResponse>(responseData);

                    return View(articlesResponse.Articles);
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
