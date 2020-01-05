using Grestau.Data.Model;

namespace Grestau.Data.Services
{
    public class Controller
    {
        /// <summary>
        /// Adds a restaurant from the database
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
            using var dbContext = new RestaurantContext();
            var restau = new Restaurant(name, phone, description, email, adress);
            dbContext.Restaurants.Add(restau);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Removes a restaurant from the database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteRestaurant(string id) //todo : should i use and id or the restaurant object it self
        {
            using var dbContext = new RestaurantContext();
            var restaurant = dbContext.Restaurants.Find(id);
            dbContext.Restaurants.Remove(restaurant);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Updates a restaurant in the database
        /// </summary>
        /// <param name="originalRestaurant"></param>
        /// <param name="modifiedRestaurant"></param>
        public void UpdateRestaurant(Restaurant originalRestaurant, Restaurant modifiedRestaurant)
        {
            if (originalRestaurant.Adress == modifiedRestaurant.Adress)
            {
                //no change
            }
        }
    }
}