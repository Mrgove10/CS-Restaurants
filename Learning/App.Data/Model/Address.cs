using System;

namespace App.Data
{
    public class Address
    {
        public Guid ID { get; set; }
        public string building { get; set; }
        public Coord coord { get; set; }
        public string street { get; set; }
        public string zipcode { get; set; }
    }
}