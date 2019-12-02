using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using App.Data.JsonRepository;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace App.Data
{
    public class Restaurant
    {
        public Guid ID { get; set; }
        public Address address { get; set; }
        public string borough { get; set; }
        public string cuisine { get; set; }
        public IList<Grade> grades { get; set; }
        public string name { get; set; }
        public string restaurant_id { get; set; }
    }
}