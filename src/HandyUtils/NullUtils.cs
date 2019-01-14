using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HandyUtils
{
    public static class NullUtils
    {
        static T ThrowIf<T>(T argument, Predicate<T> predicate, string argumentName)
        {
            if (predicate(argument))
            {
                throw new ArgumentNullException(argumentName);
            }

            return argument;
        }

        public static T ThrowIfNull<T>(this T argument, string argumentName) => 
            ThrowIf(argument, v => v == null, argumentName);

        public static Guid ThrowIfEmpty(this Guid argument, string argumentName) =>
            ThrowIf(argument, v => v == Guid.Empty, argumentName);
    }
}
