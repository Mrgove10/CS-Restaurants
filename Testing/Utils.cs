using System.Collections.Generic;
using System.Linq;

namespace Testing
{
    public class Utils
    {
        public static IEnumerable<int> GetNombrePair(IEnumerable<int> list)
        {
            IEnumerable<int> evenList = list.Where(i => i % 2 == 0 && i % 3 == 0);
            return evenList;
        }
    }
}