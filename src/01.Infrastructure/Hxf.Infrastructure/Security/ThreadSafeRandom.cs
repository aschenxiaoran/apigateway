using System;
using System.Threading;

namespace Hxf.Infrastructure.Security {
    public static class ThreadSafeRandom {

        [ThreadStatic]
        private static Random _local;

        public static Random Instance {
            get {
                if (_local != null) {
                    return _local;
                }

                var seed = unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId);
                var random = new Random(seed);

                return _local = random;
            }
        }
    }
}