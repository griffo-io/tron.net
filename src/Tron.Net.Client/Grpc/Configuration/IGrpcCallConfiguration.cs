using System;
using System.Threading;
using Grpc.Core;

namespace Tron.Net.Client.Grpc.Configuration
{
    public interface IGrpcCallConfiguration
    {
        TimeSpan? TimeOutMs { get; }

        CallOptions GetCallOptions(CancellationToken token);
    }
}
