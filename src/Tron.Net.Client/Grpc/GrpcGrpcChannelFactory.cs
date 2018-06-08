using System.Collections.Generic;
using Grpc.Core;
using Tron.Net.Client.Grpc.Configuration;

namespace Tron.Net.Client.Grpc
{

    public sealed class GrpcGrpcChannelFactory : IGrpcChannelFactory
    {
        private readonly IChannelConfiguration _channelConfiguration;        

        public GrpcGrpcChannelFactory(IChannelConfiguration channelConfiguration)
        {
            _channelConfiguration = channelConfiguration;
        }

        public Channel Create()
        {
            return _channelConfiguration.MaxConcurrentStreams.HasValue == false ?
                new Channel(_channelConfiguration.Host, _channelConfiguration.Port, ChannelCredentials.Insecure) :
                new Channel(_channelConfiguration.Host, _channelConfiguration.Port, ChannelCredentials.Insecure,
                    new List<ChannelOption>()
                    {
                        new ChannelOption(ChannelOptions.MaxConcurrentStreams, _channelConfiguration.MaxConcurrentStreams.Value)
                    });
        }

    }
}
