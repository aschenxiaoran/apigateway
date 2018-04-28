
namespace Hxf.Infrastructure
{
    public abstract class BasicEntity : OperatorRecord, IBasicAggragateRoot, IPinYinRoot
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 数据库编号
        /// </summary>
        public string DbCode { get; set; }

        

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        
        /// <summary>
        /// 拼音
        /// </summary>
        public string PinYin { get; set; }

        /// <summary>
        ///首字母
        /// </summary>
        public string FirstWord { get; set; }

        /// <summary>
        ///显示顺序
        /// </summary>
        public int SortIndex { get; set; }

        /// <summary>
        ///备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 所属公司Id
        /// </summary>
        public int CompanyId { get; set; }
    }

    public interface IBasicAggragateRoot : IAggregateRoot,IPinYinRoot
    {

        string DbCode { get; set; }
    }

    public interface IBasicSearchAggragateRoot : IBasicAggragateRoot
    {
        /// <summary>
        /// 查询字段
        /// </summary>
         string SearchText { get; set; }
    }

    public abstract class BasicUsedEntity : BasicEntity, IBasicUsedAggragateRoot
    {

        /// <summary>
        /// 是否被使用过
        /// </summary>
        public bool IsUsed { get; set; }
    }

    public interface IBasicUsedAggragateRoot : IAggregateRoot
    {
        bool IsUsed { get; set; }
    }

    public abstract class TreeEntity : OperatorRecord, IAggregateRoot, IPinYinRoot
    {
        public int Id { get; set; }

        /// <summary>
        ///Db编号
        /// </summary>
        public string DbCode { get; set; }

        public string Name { get; set; }


        public string PinYin { get; set; }

        /// <summary>
        ///昵称首字母
        /// </summary>
        public string FirstWord { get; set; }

        public string Code { get; set; }

        public int Status { get; set; }

        /// <summary>
        ///显示顺序
        /// </summary>
        public int SortIndex { get; set; }


        /// <summary>
        ///父级节点Id
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        ///是否为默认分类
        /// </summary>
        public bool IsDefault { get; set; }


        /// <summary>
        ///层级
        /// </summary>
        public int Layer { get; set; }

        public int CompanyId { get; set; }


    }
}
