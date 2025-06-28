using BlogStore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.PresentationLayer.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [Route("Article/ArticleDetail/{slug}")]
        public IActionResult ArticleDetail(string slug) // ⭐ int id yerine string slug
        {
            var article = _articleService.TGetArticleBySlug(slug);

            if (article == null)
            {
                return NotFound();
            }

            ViewBag.i = article.ArticleID; // ViewComponent'ler için ID gerekli
            return View();
        }

    }
}