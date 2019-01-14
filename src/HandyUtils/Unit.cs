using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyUtils
{
    public struct Unit : IEquatable<Unit>
    {
        public bool Equals(Unit other) => true;
        public override bool Equals(object obj) => obj is Unit;
        public override int GetHashCode() => 0;
        public override string ToString() => "()";

        public static bool operator ==(Unit first, Unit second) => true;
        public static bool operator !=(Unit first, Unit second) => false;

        public static Unit Default => default(Unit);
    }
}
