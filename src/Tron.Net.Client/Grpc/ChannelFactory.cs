using System;
using System.Collections.Generic;
using System.Threading;
using Grpc.Core;
using Tron.Net.Client.Grpc.Configuration;

namespace Tron.Net.Client.Grpc
{

    public sealed class ChannelFactory : IChannelFactory
    {
        private readonly IChannelConfiguration _channelConfiguration;        

        public ChannelFactory(IChannelConfiguration channelConfiguration)
        {
            _channelConfiguration = channelConfiguration;
        }

        public Channel CreateChannel()
        {
            return _channelConfiguration.MaxConcurrentStreams.HasValue == false ?
                new Channel(_channelConfiguration.Host, _channelConfiguration.Port, ChannelCredentials.Insecure) :
                new Channel(_channelConfiguration.Host, _channelConfiguration.Port, ChannelCredentials.Insecure,
                    new List<ChannelOption>()
                    {
                        new ChannelOption(ChannelOptions.MaxConcurrentStreams, _channelConfiguration.MaxConcurrentStreams.Value)
                    });
        }



        public CallOptions GetCallOptions(CancellationToken cancellationToken)
        {
            var deadline = DateTime.UtcNow + _channelConfiguration.TimeOutMs;
            return new CallOptions(deadline: deadline, cancellationToken: cancellationToken);
        }

    }
}
