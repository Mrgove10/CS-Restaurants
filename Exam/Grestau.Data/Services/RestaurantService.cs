using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grestau.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Grestau.Data.Services
{
    public class RestaurantService
    {
        /// <summary>
        /// Gets the list of all the restaurants
        /// </summary>
        /// <returns></returns>
        public async Task<List<Restaurant>> GetAllRestaurant()
        {
            await using var dbContext = new RestaurantContext();
            return await dbContext.Restaurants
                .Include(x => x.Adress)
                .Include(x => x.Rating)
                .ToListAsync();
        }

        /// <summary>
        /// Adds a restaurant from the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="description"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        public void AddRestaurant(
            string name,
            string phone,
            string description,
            string email,
            Adress address)
        {
            using var dbContext = new RestaurantContext();
            var restau = new Restaurant(name, phone, description, email, address);
            dbContext.Restaurants.Add(restau);
            dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a restaurant to the database
        /// </summary>
        /// <param name="restau"></param>
        public void AddRestaurant(Restaurant restau) {
            using var dbContext = new RestaurantContext();
            dbContext.Restaurants.Add(restau);
            dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Removes a restaurant from the database
        /// </summary>
        /// <param name="restau"></param>
        public void DeleteRestaurant(Restaurant restau)
        {
            using var dbContext = new RestaurantContext();
            dbContext.Restaurants.Remove(restau);
            dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a restaurant in the database
        /// </summary>
        /// <param name="modifiedRestaurant"></param>
        public async Task<Restaurant> UpdateRestaurant(Restaurant modifiedRestaurant)
        {
            await using var dbContext = new RestaurantContext();
            Console.WriteLine("updating restau");
            dbContext.Entry(modifiedRestaurant).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return modifiedRestaurant;
        }
    }
}