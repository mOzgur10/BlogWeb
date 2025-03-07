using Blog.Dal.Context;
using Blog.Dal.Repos.Concrete;
using Blog.Data.Concrete;
using Blog.Service.Concrete;
using Blog.Service.Interfaces;
using Blog.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

      


        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService)//
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var a = _categoryService.GetAll();
            
            return View(a);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
