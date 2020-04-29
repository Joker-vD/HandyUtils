using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyUtils
{
    public static class CharUtils
    {
        public static string Escape(this char c)
        {
            switch (c)
            {
                case '\x20': return "\\\x20";
                case '\r': return "\\r";
                case '\n': return "\\n";
                case '\t': return "\\t";
                case '\0': return "\\0";
                case '\\': return "\\\\";
                case '\'': return "\\'";
                case '\"': return "\\\"";
                default: return c.ToString();
            }
        }

        public static char UnescapeChar(this string s)
        {
            if (s.Length < 1 || s.Length > 2)
            {
                throw new ArgumentException("Invalid escape sequence", nameof(s));
            }

            if (s.Length == 1 && s[0] != '\\')
            {
                return s[0];
            }
            if (s.Length > 1 && s[0] == '\\')
            {
                switch (s[1])
                {
                    case 'r': return '\r';
                    case 'n': return '\n';
                    case 't': return '\t';
                    case '0': return '\0';
                    case '\x20':
                    case '\\':
                    case '"':
                    case '\'':
                        return s[1];
                }
            }
            throw new ArgumentException("Invalid escape sequence", nameof(s));
        }
    }
}
