using Grestau.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Grestau.Data.Services
{
    public class RatingService
    {
        /// <summary>
        /// Adds a new rating to the restaurant
        /// </summary>
        /// <param name="restaurant"></param>
        /// <param name="rating"></param>
        public void AddRating(Restaurant restaurant, Rating rating)
        {
            using var dbContext = new RestaurantContext();
            dbContext.Restaurants.Find(restaurant.ID).Rating = rating;
            dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Removes a rating from a restaurant
        /// </summary>
        /// <param name="restaurant"></param>
        public void RemoveRating(Restaurant restaurant)
        {
            using var dbContext = new RestaurantContext();
            dbContext.Restaurants.Find(restaurant.ID).Rating = null;
            dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// updates the rating
        /// </summary>
        /// <param name="newRating"></param>
        public void UpdateRating(Rating newRating)
        {
            using var dbContext = new RestaurantContext();
            dbContext.Entry(newRating).State = EntityState.Modified;
            dbContext.SaveChangesAsync();
        }
    }
}