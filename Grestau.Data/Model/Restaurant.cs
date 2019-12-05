using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Grestau.Data.Model
{
    public class Restaurant
    {
        [Required]
        public Guid ID;

        [Required]
        public string Name;

        [Required]
        public string Phone;

        [Required]
        public string Description;

        [Required]
        [EmailAddress]
        public string Email;

        [Required]
        public Adress Adress;

        public Rating Rating;

        public Restaurant(string name, string phone, string description, string email, Adress adress, Rating rating)
        {
            ID = new Guid();
            Name = name;
            Phone = phone;
            Description = description;
            Email = email;
            Adress = adress;
            Rating = rating;
        }
    }
}