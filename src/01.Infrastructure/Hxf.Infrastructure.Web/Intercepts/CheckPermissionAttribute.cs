using System;
using Hxf.Infrastructure.Entities;
using Hxf.Infrastructure.EventSources.ChainExecutor;
using Hxf.Infrastructure.Extensions;
using Hxf.Infrastructure.Validation;
using Hxf.Infrastructure.Web.AuthConfig;
using Hxf.Infrastructure.Web.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;
using System.Linq;

namespace Hxf.Infrastructure.Web.Intercepts {
    public class CheckPermissionAttribute : Attribute, IActionFilter {
        private string _permissionCode;
        public CheckPermissionAttribute(string permissionCode) {
            _permissionCode = permissionCode;
        }

        public void OnActionExecuted(ActionExecutedContext context) {

        }

        public void OnActionExecuting(ActionExecutingContext context) {
            bool needCheckReadApi = CheckWriteApiPermission(context);
            if (needCheckReadApi) {
                CheckReadApiPermission(context);
            }
        }

        private bool CheckWriteApiPermission(ActionExecutingContext context) {
            var commandExecutorContainer = context.HttpContext.RequestServices.GetService<ICommandExecutorContainer>();
            if (commandExecutorContainer == null) {
                return true;
            }

            var currentLoginUser = commandExecutorContainer.CommandContext.CurrentUser;
            if (!currentLoginUser.PermissonCodeList.Contains(_permissionCode)) {
                context.Result = new JsonResult(JsonResponse.CreateUnAuthorize(_permissionCode));
            }
            return false;
        }

        private void CheckReadApiPermission(ActionExecutingContext context) {
            var currentLoginUserAccessor = context.HttpContext.RequestServices.GetService<ICurrentLoginUserAccessor>();
            if (!currentLoginUserAccessor.CurrentLoginUser.PermissonCodeList.Contains(_permissionCode)) {
                context.Result = new JsonResult(JsonResponse.CreateUnAuthorize(_permissionCode));
            }
        }

    }
}