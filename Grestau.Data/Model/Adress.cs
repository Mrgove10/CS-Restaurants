using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Grestau.Data.Model
{
    public class Adress
    {
        [Required]
        public Guid ID;

        public string Rue;
        public int CodePostal;
        public string Ville;

        public Adress(string rue, int codePostal, string ville)
        {
            ID = new Guid();
            Rue = rue;
            CodePostal = codePostal;
            Ville = ville;
        }
    }
}