using System;
using System.Collections.Generic;
using System.Text;

namespace Grestau.Data.Model
{
    public class Ratings
    {
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }
    }
}
