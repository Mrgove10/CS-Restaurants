using System;
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
            }
        }
        
        [Test]
        public void AddValue()
        {
            using (var dbCtxt = new RestaurantContext())
            {
                dbCtxt.Database.EnsureCreated();
                var r = new Rating(DateTime.Now, 3, "dsfjkdslufklsdjhflksdfjsdlh");
                dbCtxt.Ratings.Add(r);
            }
        }
    }
}