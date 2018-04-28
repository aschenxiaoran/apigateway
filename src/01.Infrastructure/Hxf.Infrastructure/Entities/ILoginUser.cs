using System.Collections.Generic;
using Hxf.Infrastructure.Entities.Companys;

namespace Hxf.Infrastructure.Entities {

    /// <summary>
    /// 登陆用户接口
    /// </summary>
    public interface ILoginUser {

        /// <summary>
        /// 用户Id
        /// </summary>
        int UserId { get; set; }

        /// <summary>
        /// 公司Id
        /// </summary>
        int MemId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        string MemCode { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        string MemName { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        string Token { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        string RoleIdList { get; set; }

        /// <summary>
        /// 系统设置
        /// </summary>
        SystemConfigResponse SystemConfig { get; set; }
        /// <summary>
        /// 权限列表
        /// </summary>
        IEnumerable<string> PermissonCodeList { get; set; }
    }
}