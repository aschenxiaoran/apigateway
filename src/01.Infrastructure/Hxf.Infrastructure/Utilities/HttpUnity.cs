using System.Text.RegularExpressions;

namespace Hxf.Infrastructure.Utilities{
    public class HttpUnity{
        //public string GetIp(HttpContext httpContext)
        //{
        //    try
        //    {
        //        //如果客户端使用了代理服务器，则利用HTTP_X_FORWARDED_FOR找到客户端IP地址
        //        string userHostAddress = httpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
        //        //否则直接读取REMOTE_ADDR获取客户端IP地址
        //        if (string.IsNullOrEmpty(userHostAddress))
        //        {
        //            userHostAddress = httpContext.Request.ServerVariables["REMOTE_ADDR"];
        //        }
        //        //前两者均失败，则利用Request.UserHostAddress属性获取IP地址，但此时无法确定该IP是客户端IP还是代理IP
        //        if (string.IsNullOrEmpty(userHostAddress))
        //        {
        //            userHostAddress = httpContext.Request.UserHostAddress;
        //        }
        //        //最后判断获取是否成功，并检查IP地址的格式（检查其格式非常重要）
        //        if (!string.IsNullOrEmpty(userHostAddress) && IsIp(userHostAddress))
        //        {
        //            return userHostAddress;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return "127.0.0.1";
        //}

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIp(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

    }
}