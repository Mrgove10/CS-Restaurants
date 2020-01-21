using System.Diagnostics.CodeAnalysis;
using Grestau.Data.Model;
using Grestau.Data.Services;
using NUnit.Framework;

namespace Grestau.Data.Test
{
    [ExcludeFromCodeCoverage]
    public class RestaurantServiceTests
    {
        private RestaurantService _restaurantService;

        [SetUp]
        public void Setup()
        {
            _restaurantService = new RestaurantService();
        }

        [Test]
        public void CreateRestaurantTest()
        {
            Adress a = new Adress(12, "rue de la chevre", 38500, "voiron");
            Restaurant r = new Restaurant("le chevre", "0788888888", "bonjour je suis la description", "richardadrien@gmail.com", a);
            _restaurantService.AddRestaurant(r);
            var restId = r.ID; //this is put after because the GUID seams to be only created when the object is inserted into the database
            
            var restaurant = _restaurantService.GetAllRestaurant().Find(m => m.ID == restId);
            Assert.IsTrue(restaurant.Name == r.Name);
            Assert.IsTrue(restaurant.Phone == r.Phone);
            Assert.IsTrue(restaurant.Description == r.Description);
            Assert.IsTrue(restaurant.Email == r.Email);

            _restaurantService.DeleteRestaurant(restaurant); //deletes it to clean the database
        }

        [Test]
        public void RemoveRestaurantTest()
        {
            Adress a = new Adress(12, "rue de la mort", 38500, "voiron");
            Restaurant r = new Restaurant("la suppresion", "0788888888", "bonjour je suis la mort", "richardadrien@gmail.com", a);
            _restaurantService.AddRestaurant(r);
            var restId = r.ID;//see comment on the test above
            
            var restaurant = _restaurantService.GetAllRestaurant().Find(m => m.ID == restId);
            Assert.IsTrue(restaurant != null);

            _restaurantService.DeleteRestaurant(r); //deletes the restaurant 
            var restaurant2 = _restaurantService.GetAllRestaurant().Find(m => m.ID == restId);
            Assert.IsTrue(restaurant2 == null);
        }

        [Test]
        public void ModRestaurantTest()
        {
            Adress a = new Adress(12, "rue de la modification", 38500, "voiron");
            Restaurant r = new Restaurant("la modification", "0788888888", "bonjour je suis la modification", "richardadrien@gmail.com", a);
            _restaurantService.AddRestaurant(r);
            var restId = r.ID; //see comment on the test above

            var restaurant = _restaurantService.GetAllRestaurant().Find(m => m.ID == restId);
            Assert.IsTrue(restaurant.Description == "bonjour je suis la modification");

            Restaurant modr = restaurant;
            modr.Description = "modddd";
            _restaurantService.UpdateRestaurant(modr); //deletes the restaurant 
            var restaurant2 = _restaurantService.GetAllRestaurant().Find(m => m.ID == restId);
            Assert.IsTrue(restaurant2.Description == "modddd");
            
            _restaurantService.DeleteRestaurant(r); //deletes it to clean the database
        }
    }
}