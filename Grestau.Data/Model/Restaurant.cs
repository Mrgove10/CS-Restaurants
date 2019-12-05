using System;
using System.Collections.Generic;
using System.Text;

namespace Grestau.Data.Model
{
    public class Restaurant
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Comment { get; set; }
        public string Email { get; set; }
        public Adress Adress { get; set; }
        public Rating Rating { get; set; }
    }
}
