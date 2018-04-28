using System;

namespace Hxf.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    [Serializable]
    public class ImportColumnMapperHierarchyAttribute : ImportColumnMapperAttribute
    {
        public ImportColumnMapperHierarchyAttribute() : base()
        {

        }
        
        public ImportColumnMapperHierarchyAttribute(object defaultValue) : base (null, defaultValue)
        {
        }
    }
}
