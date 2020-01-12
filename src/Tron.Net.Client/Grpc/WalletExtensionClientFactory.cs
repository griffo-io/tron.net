namespace Tron.Net.Client.Grpc
{
    public class WalletExtensionClientFactory : IWalletExtensionClientFactory
    {
        private readonly IGrpcChannelFactory _channelFactory;

        public WalletExtensionClientFactory(IGrpcChannelFactory channelFactory)
        {
            _channelFactory = channelFactory;
        }

        public Protocol.WalletExtension.WalletExtensionClient Create()
        {
            return new Protocol.WalletExtension.WalletExtensionClient(_channelFactory.Create());
        }
    }
}
