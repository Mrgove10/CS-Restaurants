using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Return the top 5 restaurants buy rating
        /// </summary>
        /// <returns></returns>
        public async Task<List<Restaurant>> GetTopFiveRestaurant()
        {
            await using var dbContext = new RestaurantContext();
            return await dbContext.Restaurants
                .Include(x => x.Adress)
                .Include(x => x.Rating)
                .OrderByDescending(x => x.Rating.Stars)
                .Take(5)
                .ToListAsync();
        }

        /// <summary>
        /// Gets the restaurant base on an id
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<Restaurant> GetRestaurantById(Guid ID)
        {
            await using var dbContext = new RestaurantContext();
            return await dbContext.Restaurants
                .Include(x => x.Adress)
                .Include(x => x.Rating)
                .FirstAsync(x => x.ID == ID);
        }

        /// <summary>
        /// Adds a restaurant from the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="description"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        public async void AddRestaurant(
            string name,
            string phone,
            string description,
            string email,
            Adress address)
        {
            using var dbContext = new RestaurantContext();
            var restau = new Restaurant(name, phone, description, email, address);
            dbContext.Restaurants.Add(restau);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a restaurant to the database
        /// </summary>
        /// <param name="restau"></param>
        public void AddRestaurant(Restaurant restau)
        {
            using var dbContext = new RestaurantContext();
            dbContext.Restaurants.Add(restau);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Removes a restaurant from the database
        /// </summary>
        /// <param name="restau"></param>
        public void DeleteRestaurant(Restaurant restau)
        {
            using var dbContext = new RestaurantContext();
            // thse two line insure that all the information of the restaurant is removed correctly
            if (restau.Adress != null)
            {
                dbContext.Adresses.Remove(restau.Adress);
            }

            if (restau.Rating != null)
            {
                dbContext.Ratings.Remove(restau.Rating);
            }

            dbContext.Restaurants.Remove(restau);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Updates a restaurant in the database
        /// </summary>
        /// <param name="modifiedRestaurant"></param>
        public void UpdateRestaurant(Restaurant modifiedRestaurant)
        {
            using var dbContext = new RestaurantContext();
            dbContext.Entry(modifiedRestaurant).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}