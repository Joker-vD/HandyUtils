using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyUtils
{
    public static class StringUtils
    {
        public static string FormatWith(this string format, params object[] objects) =>
            string.Format(format, objects);

        public static bool IsUpper(this char c) => char.IsUpper(c);

        public static bool IsLower(this char c) => char.IsLower(c);

        public static char ToLowerInvariant(this char c) => char.ToLowerInvariant(c);

        public static char ToUpperInvariant(this char c) => char.ToUpperInvariant(c);

        public static string DecapitalizeFirstLetter(this string s)
        {
            if (string.IsNullOrEmpty(s) || !s[0].IsUpper())
            {
                return s;
            }

            var sb = new StringBuilder();

            sb.Append(s[0].ToLowerInvariant());
            sb.Append(s, 1, s.Length - 1);

            return sb.ToString();
        }

        public static string CapitalizeFirstLetter(this string s)
        {
            if (string.IsNullOrEmpty(s) || s[0].IsUpper())
            {
                return s;
            }

            var sb = new StringBuilder();

            sb.Append(s[0].ToUpperInvariant());
            sb.Append(s, 1, s.Length - 1);

            return sb.ToString();
        }


        public static string TruncateMiddle(this string str, int maxLength, string ellipsis = "...")
        {
            if (ellipsis.Length + 2 > maxLength)
            {
                throw new ArgumentException("{0} must be at least as long {1}.Length plus two".FormatWith(nameof(maxLength), nameof(ellipsis)));
            }

            if (str.Length <= maxLength)
            {
                return str;
            }

            int dataLen = maxLength - ellipsis.Length;
            int headerLen = dataLen / 2;
            int trailerLen = dataLen - headerLen;
            // headerLen + ellipsis.Length + trailerLen == maxLength

            var sb = new StringBuilder();
            sb.Append(str.Substring(0, headerLen));
            sb.Append(ellipsis);
            sb.Append(str.Substring(str.Length - trailerLen, trailerLen));

            return sb.ToString();
        }
    }
}
