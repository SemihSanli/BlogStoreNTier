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
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        private readonly BlogContext _blogContext;
        public EfCommentDal(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }

        public List<Comment> GetAllComments()
        {
            return _blogContext.Comments.ToList();
        }

        public List<Comment> GetCommentsByArticle(int id)
        {
            var values = _blogContext.Comments.Include(x => x.AppUser).Include(y => y.Article).Where(z => z.ArticleID == id).ToList();
            return values;
        }

        public List<Comment> GetLast3CommentsByArticle(string id)
        {
            var values = _blogContext.Comments
        .Include(x => x.AppUser)    
        .Include(x => x.Article)    
        .Where(x => x.Article.AppUserId == id) 
        .OrderByDescending(x => x.CommentDate)
        .Take(5)
        .ToList();

            return values;
        }

    
    }
}
