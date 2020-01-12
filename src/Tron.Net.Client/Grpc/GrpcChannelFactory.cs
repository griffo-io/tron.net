namespace Tron.Net.Client.Grpc
{

    using System.Collections.Generic;
    using Tron.Net.Client.Grpc.Configuration;
    using Channel = global::Grpc.Core.Channel;
    using ChannelCredentials  = global::Grpc.Core.ChannelCredentials;
    using ChannelOption = global::Grpc.Core.ChannelOption;
    using ChannelOptions = global::Grpc.Core.ChannelOptions;

    public sealed class GrpcChannelFactory : IGrpcChannelFactory
    {
        private readonly IChannelConfiguration _channelConfiguration;
        private Channel _channel;

        public GrpcChannelFactory(IChannelConfiguration channelConfiguration)
        {
            _channelConfiguration = channelConfiguration;
        }


        public Channel Create()
        {
            return _channel ?? (_channel = CreateChannel());
        }

        private Channel CreateChannel() => _channelConfiguration.MaxConcurrentStreams.HasValue == false
            ? new Channel(_channelConfiguration.Host, _channelConfiguration.Port, ChannelCredentials.Insecure)
            : new Channel(_channelConfiguration.Host, _channelConfiguration.Port, ChannelCredentials.Insecure,
                new List<ChannelOption>()
                {
                    new ChannelOption(ChannelOptions.MaxConcurrentStreams,
                        _channelConfiguration.MaxConcurrentStreams.Value)
                });
    }
}
