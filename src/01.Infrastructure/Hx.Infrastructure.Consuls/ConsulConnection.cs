using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Consul;
using Hxf.Infrastructure.ApiGateway.Configuration;

namespace Hx.Infrastructure.Consuls {
    public class ConsulConnection : IDisposable {

        #region private variables

        private int _proceduerCount;
        private const int MaxQueueSize = 20;
        private readonly ServiceDisconveryConfig _disconveryConfig;
        private static readonly ConcurrentQueue<ConsulClient> _consuleQueue;

        #endregion

        #region ctor

        public ConsulConnection(ServiceDisconveryConfig disconveryConfig) {
            _disconveryConfig = disconveryConfig;

        }

        static ConsulConnection() {
            _consuleQueue = new ConcurrentQueue<ConsulClient>();
        }

        #endregion

        #region implement consul connection

        public async Task<ConsulClient> Get() {

            var tryDequeue = _consuleQueue.TryDequeue(out ConsulClient consulClient);

            if (tryDequeue) {
                if (consulClient == null) {
                    consulClient = CreateConsulClient();
                }

                try {
                    consulClient.CheckDisposed();
                }
                catch (Exception e) {
                    consulClient = CreateConsulClient();
                }
                Interlocked.Decrement(ref _proceduerCount);
                return await Task.FromResult(consulClient);
            }

            var consul = CreateConsulClient();
            _consuleQueue.Enqueue(consul);
            Interlocked.Increment(ref _proceduerCount);
            return await Task.FromResult(consul);
        }


        public async Task<bool> Return(ConsulClient consulClient) {

            if (consulClient == null) {
                return await Task.FromResult(false);
            }

            if (Interlocked.Increment(ref _proceduerCount) < MaxQueueSize) {
                try {
                    consulClient.CheckDisposed();
                    _consuleQueue.Enqueue(consulClient);
                    return await Task.FromResult(true);
                }
                catch (Exception e) {
                    throw e;
                    return await Task.FromResult(false);
                }

            }
            return await Task.FromResult(false);

        }

        public void Dispose() {
            Console.WriteLine($"Dispose ConsulConnection:{_proceduerCount}");
        }

        #endregion

        #region private methods

        private ConsulClient CreateConsulClient() {
            var consul = new ConsulClient(
                 configOverride => {
                     configOverride.Address = new Uri($"http://{_disconveryConfig.Host}:{_disconveryConfig.Port}");
                 }, null, handler => {
                     handler.UseProxy = false;
                     handler.Proxy = null;
                 })
            ;
            return consul;
        }

        #endregion
    }
}