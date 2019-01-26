using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyUtils
{
    public static class HashUtils
    {
        public static int Combine(int h1, int h2)
        {
            uint num = (uint)(h1 << 5 | (int)((uint)h1 >> 27));
            return (int)num + h1 ^ h2;
        }
    }
}
