using BlogStore.BusinessLayer.Abstract;
using BlogStore.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.PresentationLayer.ViewComponents
{
    public class _AuthorDashboardProductPerformanceComponentPartial:ViewComponent
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;
        public _AuthorDashboardProductPerformanceComponentPartial(IArticleService articleService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _userManager = userManager;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var article = _articleService.TGetLast5ArticlesByUser(user.Id);
            return View(article);
        }
    }
}
