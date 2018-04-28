using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Hxf.Infrastructure.Web.Intercepts {
    /// <summary>
    /// 消息处理程序
    /// </summary>
    public class CustomMessageHandler : DelegatingHandler {

        /// <summary>
        /// 重写发送HTTP请求到内部处理程序的方法
        /// </summary>
        /// <param name="request">请求信息</param>
        /// <param name="cancellationToken">取消操作的标记</param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            try {
                ChangeLoggerDirectory(request);

                var requestIp = GetClientIp(request);
                var requestUri = request.RequestUri;
                if (request.Content != null) {

                    var requestContent = request.Content.ReadAsStringAsync().Result;
                    // _log.Warn($"{requestIp}请求{requestUri},Content:{requestContent}");
                }

                return base.SendAsync(request, cancellationToken).ContinueWith(
                    task => {
                        if (task.Result.Content != null) {
                            // _log.Warn($"{requestUri}响应{0}Content:{task.Result.Content.ReadAsStringAsync().Result}");
                        }
                        return task.Result;
                    }, cancellationToken);
            }
            catch (Exception) {

                return base.SendAsync(request, cancellationToken);
            }
           
        }

        private static void ChangeLoggerDirectory(HttpRequestMessage request) {
            // var repository = LogManager.GetRepository(String.Empty);
            // var appenders = repository.GetAppenders();
            // var targetApder = appenders.First(p => p.Name == "ActionFilterRollingLogFileAppender") as RollingFileAppender;
            // var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            // var absolutePath = request.RequestUri.AbsolutePath.Substring(1, request.RequestUri.AbsolutePath.Length - 1);
            // targetApder.File = $@"{directoryPath}Log\ActionFilter\{absolutePath}/";
            // targetApder.ActivateOptions();
        }

        private string GetClientIp(HttpRequestMessage request) {
            try {
                if (request.Properties.ContainsKey("MS_HttpContext")) {
                    return (request.Properties["MS_HttpContext"]).ToString();
                }
            }
            catch (Exception) {

            }


            return String.Empty;
        }
    }
}