using System;

namespace Hxf.Infrastructure {
    /// <summary>
    /// 聚合根接口
    /// </summary>
    public interface IAggregateRoot : IEntity, IOperateRecord {

        // /// <summary>
        // ///名称
        // /// </summary>
        // string Name { get; set; }

        // /// <summary>
        // ///编号
        // /// </summary>
        // string Code { get; set; }

        

        // /// <summary>
        // ///所属公司Id
        // /// </summary>
        // int CompanyId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        int Status { get; set; }
    }

    /// <summary>
    /// 操作记录接口
    /// </summary>
    public interface IOperateRecord{
        /// <summary>
        ///创建用户编号
        /// </summary>
        int CreateUserId { get; set; }

        /// <summary>
        ///创建用户
        /// </summary>
        string CreateUserName { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        DateTime CreateTime { get; set; }

        /// <summary>
        ///修改用户编号
        /// </summary>
        int ModifyUserId { get; set; }

        /// <summary>
        ///修改用户
        /// </summary>
        string ModifyUserName { get; set; }

        /// <summary>
        ///修改时间
        /// </summary>
        DateTime ModifyTime { get; set; }
    }

    /// <summary>
    /// 拼音接口
    /// </summary>
    public interface IPinYinRoot{

        /// <summary>
        ///昵称拼音
        /// </summary>
        string PinYin { get; set; }

        /// <summary>
        ///昵称首字母
        /// </summary>
        string FirstWord { get; set; }

    }

    /// <summary>
    /// 聚合根
    /// </summary>
    public abstract class AggregateRoot : IAggregateRoot, IPinYinRoot {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string PinYin { get; set; }
        public string FirstWord { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateTime { get; set; }
        public int ModifyUserId { get; set; }
        public string ModifyUserName { get; set; }
        public DateTime ModifyTime { get; set; }
        public int CompanyId { get; set; }
        public int Status { get; set; }
    }

    

    public interface ICategoryRelationRoot : ISaleAggregateRoot{

        int CategoryId { get; set; }
    }

    public interface IQueryKeyAggregateRoot : IAggregateRoot
    {

        string QueryKey { get; set; }
    }
}