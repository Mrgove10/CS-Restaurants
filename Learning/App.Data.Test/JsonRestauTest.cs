using System;
using System.Collections.Generic;
using System.Linq;
using App.Data.JsonRepository;
using NUnit.Framework;

namespace App.Data.Test
{
    [TestFixture]
    public class JsonRestauTest
    {
        JsonRestaurantRepository srv = new JsonRestaurantRepository();
        private List<Restaurant> result;

        [SetUp]
        public void Setup()
        {
            result = srv.LoadData(@".\Ressources\restaurants.net.json");
        }

        [Test]
        public void TestLoadData()
        {
            Assert.IsTrue(result.Count == 25357);
        }

        [Test]
        public void Test_Pizz()
        {
            Assert.IsTrue(result.FindAll(x =>
                              x.name.ToLower().Contains("pizz") &&
                              x.borough.Equals("Manhattan")).Count == 437);
        }

        [Test]
        public void Test_PizzGrade()
        {
            Assert.IsTrue(result.FindAll(x =>
                              x.name.ToLower().Contains("pizz") &&
                              x.borough.Equals("Manhattan") &&
                              x.grades.Any(g => g.grade == "A" && g.score <= 8)).Count == 274);
        }


        [Test]
        public void Test_PizzGradeKitchen()
        {
            /* Assert.IsTrue(result.FindAll(x =>
                               x.name.ToLower().Contains("pizz") &&
                               x.borough.Equals("Manhattan") &&
                               x.grades.Any(g => g.grade == "A" && g.score <= 8)).GroupBy(x => x.cuisine));*/
        }
    }
}