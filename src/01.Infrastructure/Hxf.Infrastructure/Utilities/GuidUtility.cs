using System;
using System.Linq;

namespace Hxf.Infrastructure.Utilities {

	public class GuidUtility {

		/// <summary>  
		/// 根据GUID获取16位的唯一字符串  
		/// </summary>  
		/// <param name=\"guid\"></param>  
		/// <returns></returns>  
		public static string GuidTo16String() {
			long i = Guid.NewGuid().ToByteArray().Aggregate<byte, long>(1, (current, b) => current*((int) b + 1));
			return string.Format("{0:x}", i - DateTime.Now.Ticks);
		}

		/// <summary>  
		/// 根据GUID获取19位的唯一数字序列  
		/// </summary>  
		/// <returns></returns>  
		public static long GuidToLongId() {
			byte[] buffer = Guid.NewGuid().ToByteArray();
			return BitConverter.ToInt64(buffer, 0);
		}
	}
}
