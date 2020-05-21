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

        public const string DefaultItemsSeparator = ", ";

        public static string ToItemsString<T>(this IEnumerable<T> list) =>
            list.ToItemsString(item => item.ToString(), DefaultItemsSeparator);

        public static string ToItemsString<T>(this IEnumerable<T> list, Func<T, string> converter) =>
            list.ToItemsString(converter, DefaultItemsSeparator);

        public static string ToItemsString<T>(this IEnumerable<T> list, string separator) =>
            list.ToItemsString(item => item.ToString(), separator);

        public static string ToItemsString<T>(this IEnumerable<T> list, Func<T, string> converter, string separator) =>
            string.Join(separator, list.Select(converter));

        public static string ToPrefixedItemsString<T>(this IEnumerable<T> list) =>
            list.ToPrefixedItemsString(item => item.ToString(), DefaultItemsSeparator);

        public static string ToPrefixedItemsString<T>(this IEnumerable<T> list, Func<T, string> converter) =>
            list.ToPrefixedItemsString(converter, DefaultItemsSeparator);

        public static string ToPrefixedItemsString<T>(this IEnumerable<T> list, string separator) =>
            list.ToPrefixedItemsString(item => item.ToString(), separator);

        public static string ToPrefixedItemsString<T>(this IEnumerable<T> list, Func<T, string> converter, string separator) =>
            string.Join("", list.Select(item => "{0}{1}".FormatWith(separator, converter(item))));

        public static void AssignFrom(this StringDictionary dict, IReadOnlyDictionary<string, string> data)
        {
            dict.Clear();
            foreach (var kv in data)
            {
                dict.Add(kv.Key, kv.Value);
            }
        }

        public static IEnumerable<T> Singleton<T>(T element)
        {
            yield return element;
        }

        public static IEnumerable<T> Sequence<T>(params T[] elements)
        {
            return elements;
        }
    }
}

