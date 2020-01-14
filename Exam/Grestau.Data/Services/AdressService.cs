using Grestau.Data.Model;

namespace Grestau.Data.Services
{
    public class AdressService
    {
        /// <summary>
        /// Adds the adress to a restaurant
        /// </summary>
        /// <param name="restaurant"></param>
        /// <param name="adress"></param>
        public void AddAdress(Restaurant restaurant, Adress adress)
        {
            using var dbContext = new RestaurantContext();
            restaurant.Adress = adress;
            dbContext.SaveChanges();
        }
    }
}