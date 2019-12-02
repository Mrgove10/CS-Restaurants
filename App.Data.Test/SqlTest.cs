using System.Linq;
using NUnit.Framework;

namespace App.Data.Test
{
    [TestFixture]
    public class SqlTest
    {
        [Test]
        public void InitDbConnexion()
        {
            using (var dbCtxt = new RestaurantContext())
            {
                dbCtxt.Database.EnsureCreated();
                dbCtxt.Restaurants.ToList();
            }
        }
        [Test]
        public void createRestau()
        {
            using (var dbCtxt = new RestaurantContext())
            {
                dbCtxt.Database.EnsureCreated();
                var resto = new Restaurant();
                resto.name = "jsdgjg";
                resto.address = new Address();
                resto.address.street = "trigger street";
                dbCtxt.Restaurants.Add(resto);
                dbCtxt.SaveChanges();
            }
        }
    }
}