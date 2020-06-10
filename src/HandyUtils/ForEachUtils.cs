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
            var list = items as IList<T>;
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    action(list[i], i);
                }
            }
            else
            {
                var index = 0;
                foreach (var item in items)
                {
                    action(item, index++);
                }
            }
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }
    }
}