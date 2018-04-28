using System;
using System.Threading.Tasks;
using Hxf.Infrastructure.Exceptions;
using Hxf.Infrastructure.Validation;
using Serilog;

namespace Hxf.Infrastructure.Data {
    public class ApplicationService : IApplicationService {
        private const int MaxConnectTimes = 5;
        public JsonResponse TryAction(Action action) {

            var jsonResponse = new JsonResponse();

            try {
                action();
            }
            catch (DomainException ex) {
                jsonResponse.Errors.AddErrors(ex.ValidationErrors.ErrorItems);
            }
            catch (Exception ex) {
                jsonResponse.Errors.AddSystemError();
                Log.Error(ex,"ApplicationServiceError:{0}");
            }

            return jsonResponse;
        }


        public async Task<JsonResponse> TryActionAsync(Func<Task> action) {

            var jsonResponse = new JsonResponse();

            try {
                await Task.Run(action);
            }
            catch (DomainException ex) {
                jsonResponse.Errors.AddErrors(ex.ValidationErrors.ErrorItems);
            }
            catch (Exception ex) {
                jsonResponse.Errors.AddSystemError();
                Log.Error(ex,"ApplicationServiceError:{0}");
            }

            return jsonResponse;
        }

        public async Task<TResponse> TryActionAsync<TResponse>(Func<Task> action) where TResponse : class, IJsonResponse, new() {

            var jsonResponse = new TResponse();

            try {
                await Task.Run(action);
            }
            catch (DomainException ex) {
                jsonResponse.Errors.AddErrors(ex.ValidationErrors.ErrorItems);
            }
            catch (Exception ex) {
                jsonResponse.Errors.AddSystemError();
                Log.Error(ex,"ApplicationServiceError:{0}");
            }

            return jsonResponse;
        }

        public async Task<JsonResponse> TryTransactionAsync(Func<Task> action) {

            var jsonResponse = new JsonResponse();

            try {
                using (var ctox = TransactionFactory.Required()) {
                    await Task.Run(action).ContinueWith(task => {
                        if (task.IsFaulted) {
                            throw task.Exception.InnerException;
                        }
                    });
                    ctox.Complete();
                }
            }
            catch (DomainException ex) {
                jsonResponse.Errors.AddErrors(ex.ValidationErrors.ErrorItems);
            }
            catch (AggregateException ex) {
                Log.Error(ex,"ApplicationServiceError:{0}");
            }
            catch (Exception ex) {
                var errorMessage = ex.InnerException == null ? ex.Message : ex.InnerException?.InnerException?.Message;
                jsonResponse.Errors.AddSystemError(ErrorMessage.IsAlter, errorMessage);
                jsonResponse.SystemErrorMessage = errorMessage;

            }

            return jsonResponse;
        }

        public async Task<JsonResponse> TryRepeatTransactionAsync(Func<Task> action) {

            var jsonResponse = new JsonResponse();
            var excuteCount = 0;
            Exception excutException = null;
            do {
                try {
                    await ExcuteAction(action);
                }
                catch (DomainException ex) {
                    jsonResponse.Errors.AddErrors(ex.ValidationErrors.ErrorItems);
                }
                catch (RepeateCodeException ex) {
                    excutException = ex;
                    excuteCount++;
                    if (excuteCount <= MaxConnectTimes) {
                        throw ex;
                    }
                }
                catch (AggregateException ex) {
                    Log.Error(ex,"ApplicationServiceError:{0}");
                }
                catch (Exception ex) {
                    var errorMessage = ex.InnerException == null ? ex.Message : ex.InnerException?.InnerException?.Message;
                    jsonResponse.Errors.AddSystemError(ErrorMessage.IsAlter, errorMessage);
                    jsonResponse.SystemErrorMessage = errorMessage;

                }
            } while (excutException is RepeateCodeException && excuteCount <= MaxConnectTimes);
            return jsonResponse;
        }



        protected TResponse TryAction<TResponse>(Action action) where TResponse : JsonResponse, new() {

            var jsonResponse = new TResponse();

            try {
                action();
            }
            catch (DomainException ex) {
                jsonResponse.Errors.AddErrors(ex.ValidationErrors.ErrorItems);
            }
            catch (Exception ex) {
                jsonResponse.Errors.AddSystemError();
                Log.Error(ex,"ApplicationServiceError:{0}");
            }

            return jsonResponse;
        }

        #region private methods
        private static async Task ExcuteAction(Func<Task> action) {
            using (var ctox = TransactionFactory.Required()) {
                await Task.Run(action).ContinueWith(task => {
                    if (task.IsFaulted) {
                        throw task.Exception.InnerException;
                    }
                });
                ctox.Complete();
            }
        }
        #endregion
    }

}