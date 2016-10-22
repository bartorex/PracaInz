using System;
using System.Linq;

namespace BZ.INZ.Application.IoC.Extension {
    public static class TypeExtenstions {
        public static bool ImplementGenericInterface(this Type type, Func<Type, bool> comparer) {
            return type.GetInterfaces().Any(i => i.IsGenericType && comparer(i.GetGenericTypeDefinition()));
        }

        public static bool ImplementInterface(this Type type, Type interfaceType) {
            return interfaceType.IsAssignableFrom(type);
        }
    }
}
