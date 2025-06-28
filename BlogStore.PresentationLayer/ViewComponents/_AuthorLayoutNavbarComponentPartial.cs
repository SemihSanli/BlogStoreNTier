using BlogStore.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.PresentationLayer.ViewComponents
{
    public class _AuthorLayoutNavbarComponentPartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _AuthorLayoutNavbarComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.image = user.ImageURL;
            return View();
        }
    }
}
