using System;

namespace Tron.Net.Client.Grpc.Configuration
{
    public interface IChannelConfiguration
    {
        int Port { get; }

        string Host { get; }

        int? MaxConcurrentStreams { get; }

        TimeSpan? TimeOutMs { get; }
    }
}