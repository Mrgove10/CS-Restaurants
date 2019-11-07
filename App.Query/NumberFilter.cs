using System.Collections.Generic;
using System.Linq;

namespace App.Query
{
    public class NumberFilter
    {
        /// <summary>
        /// Retruen the number in a list that are dividable by 2 and 3
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<int> GetNombreDeviceTwoThree(IEnumerable<int> list)
        {
            return list.Where(i => i % 2 == 0 && i % 3 == 0);
        }

        /// <summary>
        /// Returns a list od element that are divible by the given divided in the given list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="divider"></param>
        /// <returns></returns>
        public static IEnumerable<int> GetNumberDivider(IEnumerable<int> list, int divider)
        {
            return list.Where(i => i % divider == 0);
        }
    }
}