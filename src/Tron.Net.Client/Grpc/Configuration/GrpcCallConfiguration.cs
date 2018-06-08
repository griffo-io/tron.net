using System;
using System.Threading;
using Grpc.Core;

namespace Tron.Net.Client.Grpc.Configuration
{
    public abstract class GrpcCallConfiguration : IGrpcCallConfiguration
    {
        private static readonly TimeSpan DefaultTimeout = TimeSpan.FromMilliseconds(10000);
        
        public TimeSpan? TimeOutMs { get; } = DefaultTimeout;

        public CallOptions GetCallOptions(CancellationToken token)
        {
            var deadline = DateTime.UtcNow + TimeOutMs;
            return new CallOptions(deadline: deadline, cancellationToken: token);
        }
    }
}
