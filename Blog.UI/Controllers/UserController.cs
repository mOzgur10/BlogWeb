using Blog.Data.Concrete;
using Blog.Service.Concrete;
using Blog.Service.Interfaces;
using Blog.UI.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IArticleService articleService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _articleService = articleService;
            _categoryService = categoryService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM userLoginVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userLoginVM.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userLoginVM.Password, true, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("GirisHata", "E-mail or password is wrong!!");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("GirisHata", "E-mail or password is wrong!!");
                    return View();
                }
            }
            else
            {
                return View();
            }
            
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public async Task<IActionResult> Profile()
        {


            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }
            var articles = _articleService.GetAllActiveWhere(a => a.UserId == user.Id);
            user.Articles = articles;
            return View(user);

        }
        public async Task<IActionResult> ArticleAdd()
        {
            var categories = _categoryService.GetAll(); 
            ViewBag.Categories = categories; 

            var viewModel = new ArticleVM(); 
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ArticleAdd(ArticleVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null) return NotFound("Kullanıcı bulunamadı.");

                var article = new Article
                {
                    Title = model.Title,
                    Content = model.Content,
                    UserId = user.Id
                };

                _articleService.Add(article);

                return RedirectToAction("Profile", "User");

            }

            return RedirectToAction("Profile", "User");
        }
    }

}

