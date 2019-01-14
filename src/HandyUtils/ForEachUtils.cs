using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyUtils
{
    public static class ForEachUtils
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T, int> action)
        {
            var index = 0;
            foreach (var item in items)
            {
                action(item, index++);
            }
        }
    }
}
