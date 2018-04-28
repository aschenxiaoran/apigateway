using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Hxf.Infrastructure.Web {
    internal class UserCliamUtil {
        public static string GetUserId(HttpContext context) {

            return GetUserClaim(context) [0];
        }

        public static string GetMemId(HttpContext context) {
            return GetUserClaim(context) [1];
        }

        private static string[] GetUserClaim(HttpContext context) {
            var cliam = context.User.Claims.Where(c => c.Type == "sub").FirstOrDefault();
            if (cliam == null) {
                return new string[] { "0", "0" };
            }
            return cliam.Value.Split('|');
        }
    }
}