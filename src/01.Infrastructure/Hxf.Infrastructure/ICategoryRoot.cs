namespace Hxf.Infrastructure{
    public interface ICategoryRoot : IAggregateRoot,IPinYinRoot{
        /// <summary>
        /// 父级节点Id
        /// </summary>
        int ParentId { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        int Layer { get; set; }

        /// <summary>
        /// 排序编号
        /// </summary>
        int SortIndex { get; set; }

        /// <summary>
        /// 分类类别
        /// </summary>
        int? CategoryType { get; set; }


        string DbCode { get; set; }
    }
}