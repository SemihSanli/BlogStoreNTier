using BlogStore.DataAccessLayer.Dtos;
using BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.DataAccessLayer.Abstract
{
    public interface IArticleDal:IGenericDal<Article>
    {
        List<Article> GetArticlesWithCategories();
        public AppUser GetAppUserByArticleId(int id);
        public List<Article> GetTop3PopularArticles();
        List<Article> GetArticlesByAppUser(string id);
        public Article GetArticleWithUser(int id);
        public Article GetArticleBySlug(string slug);
        List<Article> GetArticlesByUserId(string id);
        List<Article> GetLast5ArticlesByUser(string id);
        public List<Article> GetArticlesByCategoryId(int id);
        List<(string CategoryName, int ArticleCount)> GetArticleCountByCategory();
    }
}
