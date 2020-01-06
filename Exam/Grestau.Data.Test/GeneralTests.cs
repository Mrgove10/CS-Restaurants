using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Grestau.Data.Model;
using Grestau.Data.Services;
using NUnit.Framework;

namespace Grestau.Data.Test
{
    [ExcludeFromCodeCoverage]
    public class GeneralTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConnectToDatabase()
        {
            using var dbContext = new RestaurantContext();
            dbContext.Database.EnsureCreated();
        }

        [Test]
        public void AddRandomValues()
        {
            using var dbContext = new RestaurantContext();
            dbContext.Database.EnsureCreated();

            for (int i = 0; i < 5; i++)
            {
                var a = new Adress(Utils.RandomNumber(3), Utils.RandomString(10), Utils.RandomNumber(5), Utils.RandomString(10));
                var r = new Rating(DateTime.Now, Utils.RandomNumber(1), Utils.RandomString(255));
                var rest = new Restaurant(Utils.RandomString(10), Utils.RandomNumber(6).ToString(), Utils.RandomString(10), Utils.RandomEmail(10), a, r);
                dbContext.Restaurants.Add(rest);
            }

            dbContext.SaveChanges();
        }

        [Test]
        public void CountValues()
        {
            using var dbContext = new RestaurantContext();
            dbContext.Database.EnsureCreated();
            var count = dbContext.Restaurants.Count();
            Console.WriteLine(count);
            Assert.IsTrue(count == count);
        }
    }
}