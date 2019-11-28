using System;
using System.Linq;
using App.Data.JsonRepository;
using NUnit.Framework;

namespace App.Data.Test
{
    [TestFixture]
    public class JsonRestauTest
    {
        JsonRestaurantRepository srv = new JsonRestaurantRepository();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLoadData()
        {
            var result = srv.LoadData(@".\Ressources\restaurants.net.json");
            Assert.IsTrue(result.Count == 25357);
        }

        [Test]
        public void Test_Pizz()
        {
            var result = srv.LoadData(@".\Ressources\restaurants.net.json");
            Assert.IsTrue(result.FindAll(x => 
                              x.name.ToLower().Contains("pizz") && 
                              x.borough.Equals("Manhattan")).Count == 437);
        }

        [Test]
        public void Test_PizzGrade()
        {
            var result = srv.LoadData(@".\Ressources\restaurants.net.json");
            Assert.IsTrue(result.FindAll(x => 
                              x.name.ToLower().Contains("pizz") &&
                              x.borough.Equals("Manhattan") && 
                              x.grades.Any(g => g.grade == "A" && g.score <= 8)).Count == 274);
        }
        
        
        [Test]
        public void Test_PizzGradeKitchen()
        {
            var result = srv.LoadData(@".\Ressources\restaurants.net.json");
            Assert.IsTrue(result.FindAll(x => 
                              x.name.ToLower().Contains("pizz") &&
                              x.borough.Equals("Manhattan") && 
                              x.grades.Any(g => g.grade == "A" && g.score <= 8)).Count == 274);
        }
    }
}