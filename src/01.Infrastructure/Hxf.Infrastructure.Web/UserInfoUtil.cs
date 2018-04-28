using Hxf.Infrastructure.Entities;
using Hxf.Infrastructure.Web.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Hxf.Infrastructure.Web {
    internal class UserInfoUtil {
        public static ILoginUser GetUserInfo(string userId, string url, HttpContext httpContext) {
            var requestUrl = $"{url}?userId={userId}";
            return HxfHttpClient.GetAsync<LoginUser>(httpContext, requestUrl).Result;
        }
    }
}