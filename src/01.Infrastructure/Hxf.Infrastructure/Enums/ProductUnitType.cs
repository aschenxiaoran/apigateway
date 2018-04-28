using Hxf.Infrastructure.Attributes;

namespace Hxf.Infrastructure.Enums
{
    public enum ProductUnitType
    {
        [Descriptions("基本单位")]
        Primary = 1,
        [Descriptions("副单位类型1")]
        Secondary1 = 2,
        [Descriptions("副单位类型2")]
        Secondary2 = 3
    }
}
