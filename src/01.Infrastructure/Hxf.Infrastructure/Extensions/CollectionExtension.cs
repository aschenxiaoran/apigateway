using System;
using System.Collections.Generic;
using System.Linq;

namespace Hxf.Infrastructure.Extensions
{
    public static class CollectionExtension
    {
        public static void For<T>(this IList<T> list, Action<T> action)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                action(list[i]);
            }
        }

        public static void For<T>(this IList<T> list, Func<T, bool> breakFunc)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                if (breakFunc(list[i]))
                {
                    break;
                }
            }
        }
    }
}
