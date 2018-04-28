using System.Security.Cryptography;

namespace Hxf.Infrastructure.Security
{
    public class SecretKeyProvider
    {
        public static byte[] GetSlatBytes()
        {
            //加密Key
            var slatBytes = new byte[0x10];
            //产生加密随机数
            var random = new RNGCryptoServiceProvider();
            random.GetBytes(slatBytes);
            return slatBytes;
        }
    }
}
