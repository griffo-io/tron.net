namespace Tron.Net.Client.Grpc
{
    public class WalletClientFactory : IWalletClientFactory
    {
        private readonly IGrpcChannelFactory _channelFactory;

        public WalletClientFactory(IGrpcChannelFactory channelFactory)
        {
            _channelFactory = channelFactory;
        }

        public Protocol.Wallet.WalletClient Create()
        {
            return new Protocol.Wallet.WalletClient(_channelFactory.Create());
        }
    }
}
