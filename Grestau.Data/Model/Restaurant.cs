using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Grestau.Data.Model
{
    public class Restaurant
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public Adress Adress { get; set; }

        public Rating Rating { get; set; }

        public Restaurant(string name, string phone, string description, string email, Adress address)
        {
            ID = new Guid();
            Name = name;
            Phone = phone;
            Description = description;
            Email = email;
            Adress = address;
        }
        public Restaurant(string name, string phone, string description, string email, Adress address, Rating rating)
        {
            ID = new Guid();
            Name = name;
            Phone = phone;
            Description = description;
            Email = email;
            Adress = address;
            Rating = rating;
        }

        public Restaurant()
        {
        }
    }
}