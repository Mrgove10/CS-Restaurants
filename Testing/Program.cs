using System;
using System.Collections.Generic;
using System.Linq;

namespace Testing
{
    class Program
    {
        public static List<int> listst = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};

        static void Main(string[] args)
        {
            foreach (var s in Utils.GetNombrePair(listst))
            {
                Console.WriteLine(s * 2);
            }
        }
    }
}