using System.Diagnostics.CodeAnalysis;
using Grestau.Data.Model;
using Grestau.Data.Services;
using NUnit.Framework;

namespace Grestau.Data.Test
{
    [ExcludeFromCodeCoverage]
    public class AdressServiceTest
    {
        private RestaurantService _restaurantService;
        private AdressService _adressService;
        private Restaurant _mainRestaurant;

        [SetUp]
        public void Setup()
        {
            _restaurantService = new RestaurantService();
            _adressService = new AdressService();
            _mainRestaurant = new Restaurant("le rating", "0788888888", "bonjour je suis le test de restaurant", "richardadrien@gmail.com", null);
            _restaurantService.AddRestaurant(_mainRestaurant);
        }

        [Test]
        public void CreateAdressTest()
        {
            var a = new Adress(15,"ru du 15",38500,"paris");
            _adressService.AddAdress(_mainRestaurant,a);
            var asdressid = a.ID;
            _mainRestaurant = _restaurantService.GetAllRestaurant().Result.Find(m => m.ID == _mainRestaurant.ID);// this updates the restaurant to have the correct rating id
            Assert.IsTrue(_mainRestaurant.Rating.ID == asdressid);
        }
        
        [TearDown]
        public void TearDown()
        {
            _restaurantService.DeleteRestaurant(_mainRestaurant); //cleans the test by deleting the restaurant when finishes
        }
    }
}