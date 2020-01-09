using Microsoft.EntityFrameworkCore;

namespace Grestau.Data.Model
{
    public class RestaurantContext : DbContext
    {
        private string conn;
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
            conn = @"Data Source=D:\PERSO\EPSI\B3_(2019-2020)\DotNet\CS-Restaurants\Exam\Grestau.Data\Files\Restau.db;";
        }

        public RestaurantContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(conn);
        }
    }
}