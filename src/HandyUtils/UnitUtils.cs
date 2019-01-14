using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyUtils
{
    public static class UnitUtils
    {
        public static Func<Unit> ToFunc(this Action action)
        {
            return () =>
            {
                action();
                return Unit.Default;
            };
        }

        public static Func<T, Unit> ToFunc<T>(this Action<T> action)
        {
            return (arg) =>
            {
                action(arg);
                return Unit.Default;
            };
        }
    }
}
