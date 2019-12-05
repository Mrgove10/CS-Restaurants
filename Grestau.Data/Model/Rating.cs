using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Grestau.Data.Model
{
    public class Rating
    {
        [Required]
        public Guid ID;
        public DateTime Date;
        public int Stars;
        public string Comment;

        public Rating(DateTime date, int stars, string comment)
        {
            ID = new Guid();
            Date = date;
            Stars = stars;
            Comment = comment;
        }
    }
}
