using System.IO;

namespace Hxf.Infrastructure.Extensions {
    public static class StreamExtensions {
        public static byte[] ToByteArray(this Stream stream) {
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return buffer;
        }
    }
}