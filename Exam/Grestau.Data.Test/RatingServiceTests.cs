using System.Diagnostics.CodeAnalysis;
using Grestau.Data.Model;
using Grestau.Data.Services;
using NUnit.Framework;

namespace Grestau.Data.Test
{
    [ExcludeFromCodeCoverage]
    public class RatingServiceTests
    {
        private RestaurantService _restaurantService;
        private RatingService _ratingService;
        private Restaurant _mainRestaurant;
        
        [SetUp]
        public void Setup()
        {
            _restaurantService = new RestaurantService();
            _ratingService = new RatingService();
            Adress a = new Adress(12, "rue de la chevre", 38500, "voiron");
            _mainRestaurant = new Restaurant("le chevre", "0788888888", "bonjour je suis la description", "richardadrien@gmail.com", a);
            _restaurantService.AddRestaurant(_mainRestaurant);
        }

        [Test]
        public void CreateRestaurantTest()
        {
        }

        [TearDown]
        public void TearDown()
        {
            _restaurantService.DeleteRestaurant(_mainRestaurant);//cleans the test by deleting the restaurant when finishes
        }
    }
}