using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyUtils
{
    public static class KeyValue
    {
        public static KeyValuePair<K, V> New<K, V>(K key, V value) => new KeyValuePair<K, V>(key, value);
    }
}
