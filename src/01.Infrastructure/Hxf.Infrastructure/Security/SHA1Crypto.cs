using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Hxf.Infrastructure.Security
{
    public class SHA1Crypto
    {
        public static string SHA1Hash(string password, out string secretKey)
        {
            //加密Key
            var slatBytes = SecretKeyProvider.GetSlatBytes();
            secretKey = Convert.ToBase64String(slatBytes);
            return SHA1Hash(password, slatBytes);
        }

        public static string SHA1Hash(string password)
        {
            return SHA1Hash(password, SecretKeyProvider.GetSlatBytes());
        }

        private static string SHA1Hash(string password, byte[] slatBytes)
        {
            //password转换为Byte数组
            var passwordBytes = Encoding.Unicode.GetBytes(password);
            //加密Key和password连接成新的密钥
            var combinedBytes = slatBytes.Concat(passwordBytes).ToArray();
            //SHA1加密服务类
            var sha1 = new SHA1CryptoServiceProvider();
            var hashBytes = sha1.ComputeHash(combinedBytes);
            return Convert.ToBase64String(hashBytes);
        }

        public static string SHA1Hash(string password, string passwordSalt)
        {
            return SHA1Hash(password, Convert.FromBase64String(passwordSalt));
        }
    }
}
