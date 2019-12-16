using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Grestau.Data.Model
{
    public class Rating
    {
        [Required]
        public Guid ID { get; set; }

        public DateTime Date { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }

        public Rating(DateTime date, int stars, string comment)
        {
            ID = new Guid();
            Date = date;
            Stars = stars;
            Comment = comment;
        }

        public Rating()
        {
        }
    }
}