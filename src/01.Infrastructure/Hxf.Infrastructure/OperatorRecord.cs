using System;

namespace Hxf.Infrastructure {
	/// <summary>
	/// 操作记录
	/// </summary>
	public class OperatorRecord : IValueObject {

        /// <summary>
        ///创建用户编号
        /// </summary>
        public int CreateUserId { get; set; }

        /// <summary>
        ///创建用户
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        ///修改用户编号
        /// </summary>
        public int  ModifyUserId { get; set; }

        /// <summary>
        ///修改用户
        /// </summary>
        public string ModifyUserName { get; set; }

        /// <summary>
        ///修改时间
        /// </summary>
        public DateTime  ModifyTime { get; set; }
        
    }
}
