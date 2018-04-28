using System.Text.RegularExpressions;

namespace Hxf.Infrastructure.Utilities{
    public class HttpUnity{
        //public string GetIp(HttpContext httpContext)
        //{
        //    try
        //    {
        //        //����ͻ���ʹ���˴����������������HTTP_X_FORWARDED_FOR�ҵ��ͻ���IP��ַ
        //        string userHostAddress = httpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
        //        //����ֱ�Ӷ�ȡREMOTE_ADDR��ȡ�ͻ���IP��ַ
        //        if (string.IsNullOrEmpty(userHostAddress))
        //        {
        //            userHostAddress = httpContext.Request.ServerVariables["REMOTE_ADDR"];
        //        }
        //        //ǰ���߾�ʧ�ܣ�������Request.UserHostAddress���Ի�ȡIP��ַ������ʱ�޷�ȷ����IP�ǿͻ���IP���Ǵ���IP
        //        if (string.IsNullOrEmpty(userHostAddress))
        //        {
        //            userHostAddress = httpContext.Request.UserHostAddress;
        //        }
        //        //����жϻ�ȡ�Ƿ�ɹ��������IP��ַ�ĸ�ʽ��������ʽ�ǳ���Ҫ��
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
        /// ���IP��ַ��ʽ
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIp(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

    }
}