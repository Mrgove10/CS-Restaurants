using System;
using System.Collections.Generic;
using System.Linq;
using Grestau.Data.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Grestau.Data.Services
{
    public class DataService
    {
        /// <summary>
        /// Imports the data to the database from a json string 
        /// </summary>
        /// <param name="json"></param>
        public void ImportData(string json)
        {
            using var dbContext = new RestaurantContext();
            dbContext.Database.EnsureCreated();
            var restaurantObj = JsonConvert.DeserializeObject<List<Restaurant>>(json);
            Console.WriteLine(restaurantObj.Count); //debug
            foreach (var rest in restaurantObj)
            {
                dbContext.Ratings.Add(rest.Rating);
                dbContext.Adresses.Add(rest.Adress);
                dbContext.Restaurants.Add(rest);
            }

            dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Exports the data as a json
        /// </summary>
        public void ExportData()
        {
            using var dbContext = new RestaurantContext();
            var restaurant = dbContext.Restaurants
                .Include(m => m.Adress)
                .Include(m => m.Rating)
                .ToList();
            var restaurantToJson = JsonConvert.SerializeObject(restaurant);
            Console.WriteLine(restaurantToJson);
        }

        /// <summary>
        /// Clears all tha database
        /// </summary>
        public void ClearDatabase()
        {
            using var dbContext = new RestaurantContext();
            //https://www.techonthenet.com/sqlite/truncate.php 
            //In sqlite we do not use TRUNCATE
            dbContext.Database.ExecuteSqlRaw("DELETE FROM Restaurants");
            dbContext.Database.ExecuteSqlRaw("DELETE FROM Ratings");
            dbContext.Database.ExecuteSqlRaw("DELETE FROM Adresses");
            dbContext.SaveChangesAsync();
        }
    }
}