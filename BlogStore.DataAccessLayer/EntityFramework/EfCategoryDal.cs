using BlogStore.DataAccessLayer.Abstract;
using BlogStore.DataAccessLayer.Context;
using BlogStore.DataAccessLayer.Dtos;
using BlogStore.DataAccessLayer.Repositories;
using BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly BlogContext _blogContext;
        public EfCategoryDal(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }

        public List<CategoryWithArticleCount> GetCategoryWithArticleCount()
        {
            var result = _blogContext.Categories.Select(c => new CategoryWithArticleCount
            {
                CategoryName = c.CategoryName,
                ArticleCount = _blogContext.Articles.Count(a => a.CategoryID == c.CategoryID)
            }).ToList();
            return result;
        }
    }
}
