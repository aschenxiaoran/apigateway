using Hxf.Infrastructure.Constants;
using Hxf.Infrastructure.Exceptions;
using Hxf.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Hxf.Infrastructure.Web.Intercepts {
    public class ExceptionApiFilter : ExceptionFilterAttribute {
        public override void OnException(ExceptionContext context) {
            var currentExcption = context.Exception;
            // ILog log = LogManager.GetLogger("repository", LogCategory.Error);
            // log.Error(currentExcption); //记录日志信息

            var message = context.Exception.Message;
            var domainErrorMessage = string.Empty;

            if (currentExcption is DomainException) {
                var domainExpception = currentExcption as DomainException;
                foreach (var validationError in domainExpception.ValidationErrors.ErrorItems) {
                    domainErrorMessage += validationError.ErrorMessage;
                }
            }

            if (context.Exception.InnerException != null) {
                message = context.Exception.InnerException.Message;
            }

            if (domainErrorMessage.IsNotNullOrEmpty()) {
                message = domainErrorMessage;
            }

            //context.Exception = new HttpResponseMessage {
            //    Content = new StringContent(message),
            //    StatusCode = HttpStatusCode.InternalServerError,
            //    ReasonPhrase = message
            //};
            base.OnException(context);
        }


    }
}
