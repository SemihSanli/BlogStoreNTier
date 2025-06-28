using BlogStore.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.DataAccessLayer.Context
{
    public class BlogContext:IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-33VDDOP\\SQLEXPRESS17;initial catalog=BlogStoreNTier;integrated Security=true;trust server certificate=true");
        }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Comment>Comments { get; set; }
        public DbSet<Tag>Tags { get; set; }
        public DbSet<Article>Articles { get; set; }
    }
}
