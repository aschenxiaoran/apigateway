using System;

namespace Hxf.Infrastructure.Security
{
    public class ValidateHashEncrypted
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptedHash">已加密数据</param>
        /// <param name="encryptString">未加密数据</param>
        /// <param name="encryptSalt"></param>
        /// <param name="encryptedFromat">加密方式</param>
        /// <returns></returns>
        public static bool ValidateEncrypted(string encryptedHash, string encryptString, string encryptSalt, EncryptedFromat encryptedFromat)
        {
            var encryptedString = string.Empty;
            switch (encryptedFromat)
            {
                case EncryptedFromat.SHA1:
                    encryptedString = SHA1Crypto.SHA1Hash(encryptString, encryptSalt);
                    break;
                case EncryptedFromat.MD5:
                    encryptedString = Md5Helper.MD5Encrypt(encryptString, encryptSalt);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("encryptedFromat");
            }

            return encryptedHash == encryptedString;
        }
    }
}
