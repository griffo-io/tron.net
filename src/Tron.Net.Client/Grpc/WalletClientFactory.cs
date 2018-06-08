using System;
using System.Threading;
using Grpc.Core;
using Tron.Net.Client.Grpc.Configuration;

namespace Tron.Net.Client.Grpc
{
    public class WalletClientFactory : IWalletClientFactory
    {
        private readonly IGrpcChannelFactory _grpcChannelFactory;
        private readonly IChannelConfiguration _channelConfiguration;

        public WalletClientFactory(IGrpcChannelFactory grpcChannelFactory, IChannelConfiguration channelConfiguration)
        {
            _grpcChannelFactory = grpcChannelFactory;
            _channelConfiguration = channelConfiguration;
        }

        public Protocol.Wallet.WalletClient Create()
        {
            return new Protocol.Wallet.WalletClient(_grpcChannelFactory.Create());
        }

        public CallOptions GetCallOptions(CancellationToken cancellationToken)
        {
            var deadline = DateTime.UtcNow + (_channelConfiguration.TimeOutMs ?? DefaultWalletTimeout);
            return new CallOptions(deadline: deadline, cancellationToken: cancellationToken);
        }

        public TimeSpan DefaultWalletTimeout = TimeSpan.FromMilliseconds(10000);
    }
}