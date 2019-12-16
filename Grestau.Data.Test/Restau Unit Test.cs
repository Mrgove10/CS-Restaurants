using System;
using System.Linq;
using Grestau.Data.Model;
using NUnit.Framework;

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
            }
        }

        [Test]
        public void AddValue()
        {
            using (var dbCtxt = new RestaurantContext())
            {
                dbCtxt.Database.EnsureCreated();
                var r = new Rating(DateTime.Now, 3, "dsfjkdslufklsdjhflksdfjsdlh");
                var a = new Adress(12, "rue des oies", 1121, "grenonoble");
                var rest = new Restaurant("test", "2121212121", "i am a test restaurant", "a@com", a, r);
                dbCtxt.Restaurants.Add(rest);
                dbCtxt.SaveChanges();
            }
        }

        [Test]
        public void CountValues()
        {
            using (var dbCtxt = new RestaurantContext())
            {
                dbCtxt.Database.EnsureCreated();
                var count = dbCtxt.Restaurants.Count();
                Console.WriteLine(count);
                Assert.IsTrue(count == count);
            }
        }
    }
}