using System;
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
            Adress a = new Adress(12, "rue de la rating", 38500, "voiron");
            _mainRestaurant = new Restaurant("le rating", "0788888888", "bonjour je suis la rating", "richardadrien@gmail.com", a);
            _restaurantService.AddRestaurant(_mainRestaurant);
        }

        [Test]
        public void CreateRatingTest()
        {
            Rating r = new Rating(DateTime.Now, 5, "bonjour je suis le commentaire");
            _ratingService.AddRating(_mainRestaurant, r);
            var rateid = r.ID;
            _mainRestaurant = _restaurantService.GetAllRestaurant().Find(m => m.ID == _mainRestaurant.ID);// this updates the restaurant to have the correct rating id
            Assert.IsTrue(_mainRestaurant.Rating.ID == rateid);
        }

        [Test]
        public void DeleteRatingTest()
        {
            _ratingService.RemoveRating(_mainRestaurant);
            _mainRestaurant = _restaurantService.GetAllRestaurant().Find(m => m.ID == _mainRestaurant.ID);// this updates the restaurant to have the correct rating id
            Assert.IsTrue(_mainRestaurant.Rating == null);
        }

        [Test]
        public void UpdateRatingTest()
        {
            _mainRestaurant = _restaurantService.GetAllRestaurant().Find(m => m.ID == _mainRestaurant.ID);// this updates the restaurant to have the correct rating id
            Rating modr = new Rating(DateTime.Now, 5, "bonjour je suis la modification");
            _ratingService.UpdateRating(modr);
            Assert.IsTrue(_mainRestaurant.Rating.Comment == "bonjour je suis la modification");
        }     
        
        [TearDown]
        public void TearDown()
        {
            _restaurantService.DeleteRestaurant(_mainRestaurant); //cleans the test by deleting the restaurant when finishes
        }
    }
}