using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Hxf.Infrastructure.Security
{
    public class DesCryptoHelper {

        public virtual string Encrypt(string sourceString, string key, string iv = null) {
            var encoding = Encoding.UTF8;

            var sourceBytes = encoding.GetBytes(sourceString);
            var keyBytes = encoding.GetBytes(key);
            var ivBytes = encoding.GetBytes(iv ?? key);

            var encrypted = Encrypt(sourceBytes, keyBytes, ivBytes);
            var text = encoding.GetString(encrypted);

            return text;
        }

        //public virtual string Decrypt(string ciphertext, string key, string iv = null) {
        //    var encoding = Encoding.UTF8;

        //    var sourceBytes = encoding.GetBytes(ciphertext);
        //    var keyBytes = encoding.GetBytes(key);
        //    var ivBytes = encoding.GetBytes(iv ?? key);

        //    var encrypted = Decrypt(sourceBytes, keyBytes, ivBytes);
        //    var text = encoding.GetString(encrypted);

        //    return text;
        //}


        public virtual byte[] Encrypt(byte[] sourceBytes, byte[] keyBytes, byte[] ivBytes = null) {
            if (sourceBytes == null || sourceBytes.Length == 0 || keyBytes == null || keyBytes.Length == 0) {
                return null;
            }

            if (ivBytes == null || ivBytes.Length == 0) {
                ivBytes = keyBytes;
            }

            using (var desProvider = new DESCryptoServiceProvider()) {
                desProvider.Key = keyBytes;
                desProvider.IV = ivBytes;

                using (var memoryStream = new MemoryStream()) {
                    using (var cryptoStream = new CryptoStream(memoryStream, desProvider.CreateEncryptor(), CryptoStreamMode.Write)) {
                        cryptoStream.Write(sourceBytes, 0, sourceBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        return memoryStream.ToArray();
                    }
                }
            }
        }

        //public virtual byte[] Decrypt(byte[] cipherBytes, byte[] keyBytes, byte[] ivBytes = null) {
        //    var empty = new byte[0];
        //    if (cipherBytes.IsNullOrEmpty() || keyBytes.IsNullOrEmpty()) {
        //        return empty;
        //    }

        //    if (ivBytes.IsNullOrEmpty()) {
        //        ivBytes = keyBytes;
        //    }

        //    try {
        //        using (var desProvider = new DESCryptoServiceProvider()) {
        //            desProvider.Key = keyBytes;
        //            desProvider.IV = ivBytes;

        //            var decryptor = desProvider.CreateDecryptor();
        //            using (var chiphertextStream = new MemoryStream(cipherBytes)) {
        //                using (var cryptoStream = new CryptoStream(chiphertextStream, decryptor, CryptoStreamMode.Read)) {
        //                    var buffer = new byte[cryptoStream.Length];
        //                    cryptoStream.Write(buffer, 0, buffer.Length);

        //                    return buffer;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception) {
        //        return empty;
        //    }
        //}
    }
}