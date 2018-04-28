// using Hxf.Infrastructure.Entities;
// using Hxf.Infrastructure.Entities.Companys;
// using Hxf.Infrastructure.Extensions;

// namespace Hxf.Infrastructure.Web.Security {

//     /// <summary>
//     /// 登录用户信息
//     /// </summary>
//     public class LoginUser: ILoginUser {

//         /// <summary>
//         /// 用户Id
//         /// </summary>
//         public int UserId { get; set; }

//         /// <summary>
//         /// 公司Id
//         /// </summary>
//         public int MemId { get; set; }

//         /// <summary>
//         /// 姓名
//         /// </summary>
//         public string Name { get; set; }

//         /// <summary>
//         /// 邮箱
//         /// </summary>
//         public string Email { get; set; }

//         /// <summary>
//         /// Token
//         /// </summary>
//         public string Token { get; set; }

//         /// <summary>
//         /// 角色Id
//         /// </summary>
//         public string RoleIdList { get; set; }

//         /// <summary>
//         /// 系统设置
//         /// </summary>
//         public SystemConfigResponse SystemConfig { get; set; }


//         public static LoginUser Create(int userId, int memId, string userName, string email = "", string roleIdList = null, SystemConfigResponse systemConfig=null) {
//             if (userName.IsNullOrEmpty()) {
//                 userName = email;
//             }

//             return new LoginUser {
//                 UserId = userId,
//                 MemId = memId,
//                 Name = userName,
//                 Email = email,
//                 RoleIdList = roleIdList,
//                 SystemConfig = systemConfig
//             };
//         }

//         public static LoginUser Create(LoginUser loginUser) {


//             return new LoginUser {
//                 UserId = loginUser.UserId,
//                 MemId = loginUser.MemId,
//                 Name = loginUser.Name,
//             };
//         }

        



//     }
// }