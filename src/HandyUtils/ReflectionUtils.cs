using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HandyUtils
{
    public static class ReflectionUtils
    {
        public static bool ImplementsGenericInterface(Type type, Type genericInterfaceType, out Type implementingType)
        {
            if (!genericInterfaceType.IsInterface || !genericInterfaceType.IsGenericTypeDefinition)
            {
                throw new ArgumentException("'{0}' is not a generic interface definition.".FormatWith(genericInterfaceType));
            }

            if (type.IsInterface && type.IsGenericType)
            {
                Type interfaceDefinition = type.GetGenericTypeDefinition();

                if (genericInterfaceType == interfaceDefinition)
                {
                    implementingType = type;
                    return true;
                }
            }
            
            foreach (var i in type.GetInterfaces())
            {
                if (i.IsGenericType)
                {
                    Type interfaceDefinition = i.GetGenericTypeDefinition();

                    if (genericInterfaceType == interfaceDefinition)
                    {
                        implementingType = i;
                        return true;
                    }
                }
            }

            implementingType = null;
            return false;
        }

        public static Type GetUnderlyingListItemType(Type type)
        {
            Type genericListType;
            if (ImplementsGenericInterface(type, typeof(IList<>), out genericListType))
            {
                if (!genericListType.IsGenericTypeDefinition)
                {
                    return genericListType.GenericTypeArguments[0];
                }
            }

            return null;
        }

        public static ConstructorInfo GetAnyConstructor(this Type type, params Type[] types)
        {
            return type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, types, null);
        }    
    }
}
