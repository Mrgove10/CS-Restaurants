using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace App.Data.JsonRepository
{
    public class JsonRestaurantRepository
    {
        /// <summary>
        /// Loads the data from a file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Restaurant> LoadData(string path)
        {
            var filecontent = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Restaurant>>(filecontent);
        }

        /// <summary>
        /// Write to a file
        /// </summary>
        /// <param name="listRestaurants"></param>
        /// <param name="path"></param>
        public void WriteFile(List<Restaurant> listRestaurants, string path)
        {
            
        }
    }
}