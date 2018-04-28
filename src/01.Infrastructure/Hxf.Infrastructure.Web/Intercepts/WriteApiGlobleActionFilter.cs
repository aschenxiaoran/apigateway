using Hxf.Infrastructure.Entities;
using Hxf.Infrastructure.EventSources.ChainExecutor;
using Hxf.Infrastructure.Extensions;
using Hxf.Infrastructure.Web.AuthConfig;
using Hxf.Infrastructure.Web.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Linq;

namespace Hxf.Infrastructure.Web.Intercepts {
    public class WriteApiGlobleActionFilter : IActionFilter {
        public void OnActionExecuted(ActionExecutedContext context) { }
        public void OnActionExecuting(ActionExecutingContext context) {
            InitCurrentLoginUserUtil.InitCurrentLoginUser(context);
        }

    }

    internal class InitCurrentLoginUserUtil {
        public static void InitCurrentLoginUser(ActionExecutingContext context) {
            var userId = UserCliamUtil.GetUserId(context.HttpContext);
            var actionName = context.ActionDescriptor.DisplayName;
            if (userId == "0") {
                return;
            }

            var authorizationConfig = context.HttpContext.RequestServices.GetService(typeof(IOptions<AuthorizationConfig>)) as IOptions<AuthorizationConfig>;
            var permiisionApiUrl = authorizationConfig.Value.PermissinoApiUrl;

            var commandExecutorContainer = context.HttpContext.RequestServices.GetService<ICommandExecutorContainer>();
            var currentUser = UserInfoUtil.GetUserInfo(userId, permiisionApiUrl, context.HttpContext);

            commandExecutorContainer.CommandContext.CurrentUser = currentUser;
        }

    }
}