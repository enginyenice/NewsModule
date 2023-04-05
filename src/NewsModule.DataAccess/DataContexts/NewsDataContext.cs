using Microsoft.EntityFrameworkCore;
using NewsModule.Entities.Models;

namespace NewsModule.DataAccess.DataContexts
{
    public class NewsDataContext : DbContext
    {
        public NewsDataContext(DbContextOptions<NewsDataContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<News> News { get; set; }

    }
}
