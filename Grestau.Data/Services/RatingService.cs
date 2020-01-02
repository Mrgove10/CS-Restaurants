using System;
using Grestau.Data.Model;

namespace Grestau.Data.Services
{
    public class RatingService
    {
        
        public void AddRating(DateTime date, int start, string comment, Restaurant restaurant)
        {
            using var dbCtxt = new RestaurantContext();
            Rating r = new Rating(date, start, comment);
            dbCtxt.Restaurants.Find(restaurant).Rating = r;
        }

        public void UpdateRating()
        {
        }
    }
}