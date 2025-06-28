using BlogStore.BusinessLayer.Abstract;
using BlogStore.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.PresentationLayer.ViewComponents
{
    public class _AuthorDashboardRecentCommentsComponentPartial:ViewComponent
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public _AuthorDashboardRecentCommentsComponentPartial(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var comment = _commentService.TGetLast3CommentsByArticle(user.Id);
            return View(comment);
        }
    }
}
