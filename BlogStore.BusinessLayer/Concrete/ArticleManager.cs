using BlogStore.BusinessLayer.Abstract;
using BlogStore.BusinessLayer.Helpers;
using BlogStore.DataAccessLayer.Abstract;
using BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.BusinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public List<Article> TGetArticlesByUserId(string id)
        {
            return _articleDal.GetArticlesByUserId(id);
        }

        public void TDelete(int id)
        {
            _articleDal.Delete(id);
        }

        public List<Article> TGetAll()
        {
            return _articleDal.GetAll();
        }

        public AppUser TGetAppUserByArticleId(int id)
        {
            return _articleDal.GetAppUserByArticleId(id);
        }

        public Article TGetArticleBySlug(string slug)
        {
            return _articleDal.GetArticleBySlug(slug);
        }

        public List<Article> TGetArticlesByAppUser(string id)
        {
            return _articleDal.GetArticlesByAppUser(id);

        }

        public List<Article> TGetArticlesWithCategories()
        {
            return _articleDal.GetArticlesWithCategories();
        }

        public Article TGetArticleWithUser(int id)
        {
            return _articleDal.GetArticleWithUser(id);
        }

        public Article TGetById(int id)
        {
           return _articleDal.GetById(id);
        }

        public List<Article> TGetLast5ArticlesByUser(string id)
        {
            return _articleDal.GetLast5ArticlesByUser(id);
        }

        public List<Article> TGetTop3PopularArticles()
        {
            return _articleDal.GetTop3PopularArticles();
        }

        public void TInsert(Article entity)
        {
            if (entity.ArticleTitle.Length >= 10 && entity.ArticleTitle.Length <= 100 && entity.ArticleDescription != "" && entity.ArticleImageURL.Contains("a"))
            {
                // ⭐ Otomatik slug oluştur
                entity.Slug = SlugHelper.GenerateSlug(entity.ArticleTitle);

                // Aynı slug varsa sonuna sayı ekle
                int counter = 1;
                string originalSlug = entity.Slug;
                while (_articleDal.GetAll().Any(x => x.Slug == entity.Slug))
                {
                    entity.Slug = $"{originalSlug}-{counter}";
                    counter++;
                }

                _articleDal.Insert(entity);
            }
            else
            {
                //hata mesaji
            }
        }

        public void TUpdate(Article entity)
        {
            // ⭐ Güncelleme sırasında slug'ı yeniden oluştur
            entity.Slug = SlugHelper.GenerateSlug(entity.ArticleTitle);

            // Aynı slug varsa ve farklı makale ise sonuna sayı ekle
            int counter = 1;
            string originalSlug = entity.Slug;
            while (_articleDal.GetAll().Any(x => x.Slug == entity.Slug && x.ArticleID != entity.ArticleID))
            {
                entity.Slug = $"{originalSlug}-{counter}";
                counter++;
            }

            _articleDal.Update(entity);
        }

        public List<Article> TGetArticlesByCategoryId(int id)
        {
            return _articleDal.GetArticlesByCategoryId(id);
        }

        public List<(string CategoryName, int ArticleCount)> TGetArticleCountByCategory()
        {
            return _articleDal.GetArticleCountByCategory();
        }
    }
}
