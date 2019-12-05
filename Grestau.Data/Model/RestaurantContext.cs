using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Grestau.Data.Model
{
    public class RestaurantContext : DbContext
    {
        private string conn { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public RestaurantContext()
        {
            // conn = "Server=stephan-server-xl.duckdns.org;Port=3306;Database=TestUser_CSharp;User=TestUser_CSharp;password=op8V6jus8rVtHlku";
            conn = @"Server=DESKTOP-G94QRTM\SQLExpress;Database=TestUser_CSharp;trusted_connection=true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conn);
        }
    }
}