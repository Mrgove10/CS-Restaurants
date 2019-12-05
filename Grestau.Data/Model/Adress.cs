﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Grestau.Data.Model
{
    public class Adress
    {
        [Required]
        public Guid ID { get; set; }
        public string Rue { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
    }
}
