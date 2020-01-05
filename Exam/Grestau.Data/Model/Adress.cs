using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Grestau.Data.Model
{
    public class Adress
    {
        [Required]
        public Guid ID { get; set; }

        public int Numero { get; set; }
        public string Rue { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }

        public Adress(int numero, string rue, int codePostal, string ville)
        {
            ID = new Guid();
            Rue = rue;
            CodePostal = codePostal;
            Ville = ville;
            Numero = numero;
        }

        public Adress()
        {
        }
    }
}