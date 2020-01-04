using System;
using Grestau.Data.Model;
using Newtonsoft.Json;

namespace Grestau.Data.Services
{
    public class DataService
    {
        public void ImportData()
        {
        }

        public void ExportData()
        {
            using var dbCtxt = new RestaurantContext();
            var restaurant = dbCtxt.Restaurants;
            var restaurantToJson = JsonConvert.SerializeObject(restaurant);
            Console.WriteLine(restaurantToJson);
        }    
    }
}