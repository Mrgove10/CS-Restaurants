using System;
using System.Collections.Generic;
using System.Linq;

namespace Testing
{
    class Program
    {
        public static List<int> originalList = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};

        static void Main(string[] args)
        {
            foreach (var s in Utils.GetNombreDeviceTwoThree(originalList))
            {
                Console.WriteLine(s * 2);
            }

            Console.WriteLine();
            var d = int.Parse(Console.ReadLine());
            foreach (var c in Utils.GetNumberDivider(originalList, d))
            {
                Console.WriteLine(c);
            }
        }
    }
}