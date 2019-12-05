using Microsoft.EntityFrameworkCore;

namespace Grestau.Data.Model
{
    public class RestaurantContext : DbContext
    {
        private string conn;
        public DbSet<Restaurant> Restaurants;
        public DbSet<Adress> Adresses;
        public DbSet<Rating> Ratings;

        public RestaurantContext()
        {
            // conn = "Server=stephan-server-xl.duckdns.org;Port=3306;Database=TestUser_CSharp;User=TestUser_CSharp;password=op8V6jus8rVtHlku";
            //conn = @"Server=DESKTOP-G94QRTM\SQLExpress;Database=TestUser_CSharp;trusted_connection=true";
            conn = @"Data Source=D:\PERSO\EPSI\B3_(2019-2020)\DotNet\CS-Restaurants\Grestau.Data\Files\Restau.db;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(conn);
            optionsBuilder.UseSqlite(conn);
        }
    }
}