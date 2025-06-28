using BlogStore.BusinessLayer.Abstract;
using BlogStore.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogStore.PresentationLayer.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public AuthorController(IArticleService articleService, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        public async Task<IActionResult> GetPorfile()
        {
            var userProfile = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = userProfile.Name;
            ViewBag.surname=userProfile.Surname;
            ViewBag.username=userProfile.UserName;
            ViewBag.imageurl=userProfile.ImageURL;
            ViewBag.email=userProfile.Email;
           ViewBag.id = userProfile.Id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(AppUser updatedUser, string profileImageUrl, string newPassword)
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = updatedUser.Name;
            user.Surname = updatedUser.Surname;
            user.UserName = updatedUser.UserName;
            user.Email = updatedUser.Email;

            if (!string.IsNullOrEmpty(profileImageUrl))
            {
                user.ImageURL = profileImageUrl;
            }

            if (!string.IsNullOrEmpty(newPassword))
            {
                var hasPassword = await _userManager.HasPasswordAsync(user);
                if (hasPassword)
                {
                    var removeResult = await _userManager.RemovePasswordAsync(user);
                    if (!removeResult.Succeeded)
                    {
                        foreach (var error in removeResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return View("GetPorfile", user);
                    }
                }

                var addResult = await _userManager.AddPasswordAsync(user, newPassword);
                if (!addResult.Succeeded)
                {
                    foreach (var error in addResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View("GetPorfile", user);
                }
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Profil başarıyla güncellendi!";
                return RedirectToAction("UserLogin", "Login");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("GetPorfile", user);
            }
        }


        [HttpGet]
        public async Task<IActionResult> CreateArticle()
        {
            List<SelectListItem> values = (from x in _categoryService.TGetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            var userProfile = await _userManager.FindByNameAsync(User.Identity.Name);
            article.AppUserId = userProfile.Id;
            article.CreatedDate = DateTime.Now;

            _articleService.TInsert(article);
            return RedirectToAction("Index","Default");
        }
        public async Task<IActionResult> MyArticleList()
        {
            var userProfile = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesByAppUser(userProfile.Id);
            return View(values);
        }
    }
}
