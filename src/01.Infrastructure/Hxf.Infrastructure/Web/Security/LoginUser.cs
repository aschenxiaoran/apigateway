using System.Collections.Generic;
using Hxf.Infrastructure.Entities;
using Hxf.Infrastructure.Entities.Companys;
using Hxf.Infrastructure.Extensions;

namespace Hxf.Infrastructure.Web.Security {

    /// <summary>
    /// 登录用户信息
    /// </summary>
    public class LoginUser : ILoginUser {
        public LoginUser() {
            PermissonCodeList = new List<string>();
        }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 公司Id
        /// </summary>
        public int MemId { get; set; }
        /// <summary>
        /// 公司Code
        /// </summary>
        public string MemCode { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string MemName { get; set; }
        /// <summary>
        /// 用户Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public string RoleIdList { get; set; }

        /// <summary>
        /// 系统设置
        /// </summary>
        public SystemConfigResponse SystemConfig { get; set; }

        /// <summary>
        /// 权限列表
        /// </summary>
        public IEnumerable<string> PermissonCodeList { get; set; }

        public static LoginUser Create(
            int userId,
            int memId,
            string userCode = null,
            string memCode = null,
            string userName = null,
            string memName = null) {
            var user = new LoginUser {
            UserId = userId,
            Code = userCode,
            Name = userName,
            MemId = memId,
            MemCode = memCode,
            MemName = memName
            };
            return user;
        }

        public static LoginUser CreateEmpty() {
            return new LoginUser();
        }

        public static LoginUser Create(LoginUser loginUser) {
            var user = new LoginUser {
                UserId = loginUser.UserId,
                Code = loginUser.Code,
                Name = loginUser.Name,
                MemId = loginUser.MemId,
                MemCode = loginUser.MemCode,
                MemName = loginUser.MemName
            };

            return user;
        }

    }
}