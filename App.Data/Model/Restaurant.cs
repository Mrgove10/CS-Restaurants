using System.Collections.Generic;

namespace App.Data
{
    public class Coord
    {
        public string type { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }

    public class Address
    {
        public string building { get; set; }
        public Coord coord { get; set; }
        public string street { get; set; }
        public string zipcode { get; set; }
    }

    public class Grade
    {
        public double date { get; set; }
        public string grade { get; set; }
        public int score { get; set; }
    }

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