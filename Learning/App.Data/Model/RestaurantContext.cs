using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class RestaurantContext : DbContext
    {
        private string con { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Coord> Coords { get; set; }
        public DbSet<Address> Adresses { get; set; }

        public RestaurantContext()
        {
            con = @"Data Source=D:\PERSO\EPSI\B3_(2019-2020)\DotNet\CS-Restaurants\App.Data\RestauDB.db;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(con);
        }
    }
}