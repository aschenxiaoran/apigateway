using System;
using System.Threading.Tasks;
using Hxf.Infrastructure.ApiGateway.Middleware;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Hxf.Infrastructure.ApiGateway.Errors.Middleware {
    public class UncaughtExceptionMiddleware : AbstractMiddleware {

        private readonly RequestDelegate _nextStep;

        public UncaughtExceptionMiddleware(RequestDelegate nextStep, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) {
            _nextStep = nextStep;
        }

        public override async Task Invoke(HttpContext context) {
            try {
                await _nextStep.Invoke(context);
            }
            catch (Exception ex) {
                Log.Error("error call middlware");
                Log.Error(ex.Message);
                Log.Error(ex.StackTrace);
            }

        }
    }
}
