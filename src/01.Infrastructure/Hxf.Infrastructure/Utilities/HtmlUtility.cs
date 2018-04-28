using System.Web;

namespace Hxf.Infrastructure.Utilities {
	
	
	public class HtmlUtility {

		/// <summary>
		/// 替换html字符
		/// 
		/// </summary>
		public static string EncodeHtml(string str) {
			if (!string.IsNullOrEmpty(str))
				return HttpUtility.HtmlEncode(str);
			return "";
		}

        
    }
}
