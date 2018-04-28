using System;

namespace Hxf.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    [Serializable]
    public class PrintColumnHierarchyAttribute : Attribute
    {
        public PrintColumnHierarchyAttribute() { }
    }
}
