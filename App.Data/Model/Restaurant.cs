using System.Collections.Generic;
using System.Text.Json.Serialization;
using App.Data.JsonRepository;

namespace App.Data
{
    public class Restaurant
    {
        public Address address { get; set; }
        public string borough { get; set; }
        public string cuisine { get; set; }
        public IList<Grade> grades { get; set; }
        public string name { get; set; }
        public string restaurant_id { get; set; }
    }
}