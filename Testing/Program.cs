using System;
using System.Collections.Generic;
using System.Data;
using App.Query;

namespace Testing
{
    class Program
    {
        public static List<int> originalList = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};

        /// <summary>
        /// Entry point of the test program
        /// </summary>
        static void Main()
        {
            foreach (var s in NumberFilter.GetNombreDeviceTwoThree(originalList))
            {
                Console.WriteLine(s * 2);
            }

            Console.WriteLine();
            var d = int.Parse(Console.ReadLine() ?? throw new NoNullAllowedException());
            foreach (var c in NumberFilter.GetNumberDivider(originalList, d))
            {
                Console.WriteLine(c);
            }
        }
    }
}