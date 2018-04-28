using System;
using System.Threading.Tasks;
using Hxf.Infrastructure.Exceptions;
using Hxf.Infrastructure.Validation;
using Serilog;

namespace Hxf.Infrastructure.Data {
    public class ApiQueryService : IApplicationQueryService {

        public JsonResponse TryAction(Action action) {

            var jsonResponse = new JsonResponse();

            try {
                action();
            } catch (DomainException ex) {
                jsonResponse.Errors.AddErrors(ex.ValidationErrors.ErrorItems);

            } catch (Exception ex) {
                jsonResponse.Errors.AddSystemError();
                Log.Error(ex, "error:{0}");
            }

            return jsonResponse;
        }

        public async Task<JsonResponse> TryActionAsync(Func<Task> action) {

            var jsonResponse = new JsonResponse();

            try {
                await Task.Run(action);
            } catch (DomainException ex) {
                jsonResponse.Errors.AddErrors(ex.ValidationErrors.ErrorItems);
            } catch (Exception ex) {
                jsonResponse.Errors.AddSystemError();
                Log.Error(ex, "error:{0}");
            }

            return jsonResponse;
        }

    }
}