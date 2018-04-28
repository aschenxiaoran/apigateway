using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Hxf.Infrastructure.Extensions
{
    public static class TypeExtension
    {
        /// <summary>
        /// 返回程序集已加载类类型
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch(ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }
    }
}
