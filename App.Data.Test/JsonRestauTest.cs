using System;
using App.Data.JsonRepository;
using NUnit.Framework;

namespace App.Data.Test
{
    [TestFixture]
    public class JsonRestauTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLoadData()
        {
            var srv = new JsonRestaurantRepository();
            var result = srv.LoadData("D:\\PERSO\\EPSI\\B3_(2019-2020)\\DotNet\\CS-Restaurants\\App.Data.Test\\Ressources\\restaurants.net.json");
            Assert.IsTrue(result.Count == 25357);
        }
    }
}