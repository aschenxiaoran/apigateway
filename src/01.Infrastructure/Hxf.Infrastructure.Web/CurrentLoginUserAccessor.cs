using System;
using Hxf.Infrastructure.Entities;
using Hxf.Infrastructure.Web.AuthConfig;
using Hxf.Infrastructure.Web.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using Serilog;

namespace Hxf.Infrastructure.Web {
    public interface ICurrentLoginUserAccessor {
        ILoginUser CurrentLoginUser { get; }
    }

    public class CurrentLoginUserAccessor : ICurrentLoginUserAccessor {
        private IHttpContextAccessor _httpContextAccessor;

        public CurrentLoginUserAccessor(IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
        }
        public ILoginUser CurrentLoginUser {
            get {
                try {
                    var userId = UserCliamUtil.GetUserId(_httpContextAccessor.HttpContext);

                    var authorizationConfig = _httpContextAccessor.HttpContext.RequestServices.GetService(typeof(IOptions<AuthorizationConfig>)) as IOptions<AuthorizationConfig>;
                    var permisionApiUrl = authorizationConfig.Value.PermissinoApiUrl;

                    return UserInfoUtil.GetUserInfo(userId, permisionApiUrl, _httpContextAccessor.HttpContext);
                } catch (Exception e) {
                    Log.Error(e, "获取当前登录用户出错");
                }

                return LoginUser.CreateEmpty();
            }
        }
    }
}