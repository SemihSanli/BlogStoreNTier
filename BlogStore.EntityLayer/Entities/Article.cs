using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.EntityLayer.Entities
{
    public class Article
    {
        public int ArticleID { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleImageURL { get; set; }
        public string ArticleDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Slug { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public string? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
