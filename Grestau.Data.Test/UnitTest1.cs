using Grestau.Data.Model;
using NUnit.Framework;
using System.Linq;

namespace Grestau.Data.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConnectToDatabase()
        {
            using (var dbCtxt = new RestaurantContext())
            {
                dbCtxt.Database.EnsureCreated();
                dbCtxt.Restaurants.ToList();
                dbCtxt.Ratings.ToList();
                dbCtxt.Adresses.ToList();
                //Assert.IsTrue(true);
            }
        }
    }
}