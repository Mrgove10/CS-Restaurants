using System;

namespace App.Data
{
    public class Coord
    {    
        public Guid ID { get; set; }
        public string type { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}