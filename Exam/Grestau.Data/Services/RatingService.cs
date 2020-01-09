using System;
using Grestau.Data.Model;

namespace Grestau.Data.Services
{
    public class RatingService
    {
        /// <summary>
        /// Adds a new rating to the restaurant
        /// </summary>
        /// <param name="date"></param>
        /// <param name="start"></param>
        /// <param name="comment"></param>
        /// <param name="restaurant"></param>
        public void AddRating(DateTime date, int start, string comment, Restaurant restaurant)
        {
            using var dbContext = new RestaurantContext();
            Rating r = new Rating(date, start, comment);
            dbContext.Restaurants.Find(restaurant).Rating = r;
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Removes a rating from a restaurant
        /// </summary>
        /// <param name="restaurant"></param>
        public void RemoveRating(Restaurant restaurant)
        {
            using var dbContext = new RestaurantContext();
            dbContext.Restaurants.Find(restaurant).Rating = null;
            dbContext.SaveChanges();
        }

        /// <summary>
        /// updates the rating
        /// </summary>
        /// <param name="restaurant"></param>
        /// <param name="newRating"></param>
        public void UpdateRating(Restaurant restaurant, Rating newRating)
        {
            using var dbContext = new RestaurantContext();
            dbContext.Restaurants.Find(restaurant).Rating = newRating;//todo : i dont think thiw will work
            dbContext.SaveChanges();
        }
    }
}