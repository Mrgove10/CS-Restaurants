using System.Collections.Generic;
using System.Linq;

namespace App.Query
{
    public static class NumberFilter
    {

        /// <summary>
        /// Returns a list od element that are divible by the given divided in the given list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="divider"></param>
        /// <returns></returns>
        public static IEnumerable<int> GetNumberDivider(this IEnumerable<int> list, int divider)
        {
            return list.Where(i => i % divider == 0);
        }
    }
}