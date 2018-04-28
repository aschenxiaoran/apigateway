using Hxf.Infrastructure.Entities;
using Hxf.Infrastructure.EventSources.ChainExecutor;
using Hxf.Infrastructure.Extensions;
using Hxf.Infrastructure.Paging;
using Hxf.Infrastructure.Web.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Linq;

namespace Hxf.Infrastructure.Web.Intercepts {
    public class ReadApiGlobleActionFilter : IActionFilter {
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context) {
            InitQueryDtoUtil.InitQueryDto(context);
        }
    }

    internal class InitQueryDtoUtil {
        public static void InitQueryDto(ActionExecutingContext context) {
            foreach (var argument in context.ActionArguments) {
                if (argument.Value.GetType().BaseType == typeof(PageQueryDto)) {
                    var queryDto = argument.Value as PageQueryDto;
                    queryDto.UserId = UserCliamUtil.GetUserId(context.HttpContext).ToInt32().GetValueOrDefault();
                    queryDto.MemId = UserCliamUtil.GetMemId(context.HttpContext).ToInt32().GetValueOrDefault();
                }
            }
        }
    }
}