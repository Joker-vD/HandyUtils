using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyUtils
{
    public static class EnumerableUtils
    {
        public static Dictionary<K, V> ToDictionary<K, V>(this IEnumerable<KeyValuePair<K, V>> sequence) =>
            sequence.ToDictionary(kv => kv.Key, kv => kv.Value);

        public static string ToItemsString<T>(this IEnumerable<T> list) =>
            list.ToItemsString(item => item.ToString());

        public static string ToItemsString<T>(this IEnumerable<T> list, Func<T, string> converter) =>
            string.Join(", ", list.Select(converter));

        public static void AssignFrom(this StringDictionary dict, IReadOnlyDictionary<string, string> data)
        {
            dict.Clear();
            foreach (var kv in data)
            {
                dict.Add(kv.Key, kv.Value);
            }
        }
    }
}

