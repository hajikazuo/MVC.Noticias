using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NoticiasMvc.Models;
using NoticiasMvc.Services.Interfaces;
using NoticiasMvc.Settings;
using System.Diagnostics;

namespace NoticiasMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsService _newsService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(INewsService newsService, ILogger<HomeController> logger)
        {
            _newsService = newsService; 
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            var News = await _newsService.GetNewsAsync();   

            return View(News);            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
