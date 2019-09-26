using Microsoft.EntityFrameworkCore;
using netCoreWorkshop.Entities;

namespace netCoreWorkshop.Data
{
    public class ArticlesContext : DbContext
    {
        public ArticlesContext(DbContextOptions options) :
            base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./articles.db");
        }
    }
}