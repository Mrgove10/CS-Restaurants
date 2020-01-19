using System;
using System.ComponentModel.DataAnnotations;

namespace Grestau.Data.Model
{
    public class Rating
    {
        [Required]
        public Guid ID { get; set; }

        public DateTime Date { get; set; }

        [Range(0, 10)]
        public int Stars { get; set; }

        [MaxLength(255)]
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