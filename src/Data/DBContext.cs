using Microsoft.EntityFrameworkCore;
using netCoreWorkshop.Entities;

namespace netCoreWorkshop.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) :
            base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Filename=./articles.db");
        }
    }
}