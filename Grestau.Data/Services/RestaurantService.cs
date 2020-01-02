using Grestau.Data.Model;

namespace Grestau.Data.Services
{
    public class Controller
    {
        /// <summary>
        /// Adds a restaurant
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="description"></param>
        /// <param name="email"></param>
        /// <param name="adress"></param>
        public void AddRestaurant(
            string name,
            string phone,
            string description,
            string email,
            Adress adress)
        {
            using var dbCtxt = new RestaurantContext();
            var restau = new Restaurant(name, phone, description, email, adress);
            dbCtxt.Restaurants.Add(restau);
            dbCtxt.SaveChanges();
        }

        /// <summary>
        /// Removes a restaurant
        /// </summary>
        /// <param name="id"></param>
        public void DeleteRestaurant(string id) //todo : should i use and id or the restaurant object it self
        {
            using var dbCtxt = new RestaurantContext();
            var restaurant = dbCtxt.Restaurants.Find(id);
            dbCtxt.Restaurants.Remove(restaurant);
            dbCtxt.SaveChanges();
        }

        public void UpdateRestaurant(Restaurant originalRestaurant, Restaurant modifiedRestaurant)
        {
            if (originalRestaurant.Adress == modifiedRestaurant.Adress)
            {
                //no change
            }
        }
    }
}