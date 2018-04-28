// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using System.Windows.Input;
// using Hxf.Infrastructure.Data;
// using Hxf.Infrastructure.EventSources.Ioc;
// using Hxf.Infrastructure.Exceptions;
// using Hxf.Infrastructure.Validation;

// namespace Hxf.Infrastructure.EventSources {
//     /// <summary>
//     /// 命令总线
//     /// </summary>
//     public class CommandBus {
//         #region private methods

//         private List<ICommandExecutor> executorList = new List<ICommandExecutor>();

//         #endregion

//         #region public methods

//         public async Task<JsonResponse> Send<TCommand>(TCommand command) where TCommand : class, ICommand, new() {
//             var response = await TryActionAsync(async() => {

//                 foreach (var excutor in executorList) {
//                     await excutor.Excute(command);
//                 }
//             });

//             return response;
//         }

//         public async Task<JsonResponse> SendTrans<TCommand>(TCommand command) where TCommand : class, ICommand, new() {
//             var response = await TryTransactionAsync(async() => {

//                 foreach (var excutor in executorList) {
// begimntrasaction
//                     await excutor.Excute(command);
//                 }
//commit()
//             });

//             return response;
//         }

//         public CommandBus Register<TCommandRequest>()
//         where TCommandRequest : class, ICommand, new() {
//             var excutor = IocContainer.Resolve<IList<ICommandExecutor<TCommandRequest>> >();
//             executorList.AddRange(excutor);

//             return this;
//         }

//         #endregion

//         #region private methods

//         private static async Task<JsonResponse> TryActionAsync(Func<Task> action) {

//             var jsonResponse = new JsonResponse();

//             try {
//                 await Task.Run(action);
//             } catch (DomainException ex) {
//                 jsonResponse.Errors.AddErrors(ex.ValidationErrors.ErrorItems);
//             } catch (Exception ex) {
//                 jsonResponse.Errors.AddSystemError();
//                 //_logger.Error(ex);
//             }

//             return jsonResponse;
//         }

//         private static async Task<JsonResponse> TryTransactionAsync(Func<Task> action) {

//             var jsonResponse = new JsonResponse();

//             try {
//                 using(var ctox = TransactionFactory.Required()) {
//                     await Task.Run(action).ContinueWith(task => {
//                         if (task.IsFaulted) {
//                             throw task.Exception.InnerException;
//                         }
//                     });
//                     ctox.Complete();
//                 }
//             } catch (DomainException ex) {
//                 jsonResponse.Errors.AddErrors(ex.ValidationErrors.ErrorItems);
//             } catch (AggregateException ex) {
//                 //_logger.Error(ex);
//             } catch (Exception ex) {
//                 //_logger.Error(ex);
//                 var errorMessage = ex.InnerException == null ? ex.Message : ex.InnerException?.InnerException?.Message;
//                 jsonResponse.Errors.AddSystemError("IsAlter", errorMessage);
//                 jsonResponse.SystemErrorMessage = errorMessage;

//             }

//             return jsonResponse;
//         }

//         #endregion
//     }

// }