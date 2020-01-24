using Microsoft.EntityFrameworkCore;

namespace Grestau.Data.Model
{
    public class RestaurantContext : DbContext
    {
        //TODO: Change me !
        
        private string conn = @"Data Source=D:\PERSO\EPSI\B3_(2019-2020)\DotNet\CS-Restaurants\Exam\Grestau.Data\Files\Restau.db;";
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        /// <summary>
        /// Init of the context
        /// please do not remove me 
        /// </summary>
        /// <param name="options"></param>
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
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