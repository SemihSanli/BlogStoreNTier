using BlogStore.DataAccessLayer.Abstract;
using BlogStore.DataAccessLayer.Context;
using BlogStore.DataAccessLayer.Repositories;
using BlogStore.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.DataAccessLayer.EntityFramework
{
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        private readonly BlogContext _blogContext;
        public EfArticleDal(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }

        public AppUser GetAppUserByArticleId(int id)
        {
            string userId = _blogContext.Articles.Where(x => x.ArticleID == id).Select(y => y.AppUserId).FirstOrDefault();
            var userValue = _blogContext.Users.Where(x => x.Id == userId).FirstOrDefault();
            return userValue;
        }

        public Article GetArticleBySlug(string slug)
        {
            return _blogContext.Articles
         .Include(x => x.AppUser)
         .Include(x => x.Category)
         .FirstOrDefault(x => x.Slug == slug);
        }

        public List<Article> GetArticlesByAppUser(string id)
        {
            return _blogContext.Articles.Where(x => x.AppUserId == id).Include(x => x.Category).ToList();

        }

        public List<Article> GetArticlesByUserId(string id)
        {
            return _blogContext.Articles
       .Include(x => x.AppUser)
       .Include(x => x.Category)
       .Where(x => x.AppUserId == id)
       .OrderByDescending(x => x.CreatedDate)
       .ToList();
        }

        public List<Article> GetArticlesWithCategories()
        {
            return _blogContext.Articles.Include(x => x.Category).ToList();
        }



        public Article GetArticleWithUser(int id)
        {
            return _blogContext.Articles.Include(x => x.AppUser).FirstOrDefault(x => x.ArticleID == id);
        }

        public List<Article> GetLast5ArticlesByUser(string id)
        {
            return _blogContext.Articles
        .Where(a => a.AppUserId == id)
        .OrderByDescending(a => a.CreatedDate)
        .Take(5)
        .ToList();
        }



        public List<Article> GetTop3PopularArticles()
        {
            var values = _blogContext.Articles.OrderByDescending(x => x.ArticleID).Take(3).ToList();
            return values;
        }

        public List<Article> GetArticlesByCategoryId(int id)
        {
            return _blogContext.Articles
       .Include(a => a.Category)
       .Include(a => a.AppUser)
       .Where(a => a.CategoryID == id)
       .ToList();
        }

        public List<(string CategoryName, int ArticleCount)> GetArticleCountByCategory()
        {
            var result = _blogContext.Articles
            .Include(a => a.Category)
            .GroupBy(a => a.Category.CategoryName)
            .Select(g => new ValueTuple<string, int>(
                g.Key,
                g.Count()
            ))
            .ToList();

            return result;
        }
    }
}
