namespace Tron.Net.Client.Grpc
{
    public class WalletExtensionClientFactory : IWalletExtensionClientFactory
    {
        private readonly IGrpcChannelFactory _grpcChannelFactory;

        public WalletExtensionClientFactory(IGrpcChannelFactory grpcChannelFactory)
        {
            _grpcChannelFactory = grpcChannelFactory;
        }

        public Protocol.WalletExtension.WalletExtensionClient Create()
        {
            return new Protocol.WalletExtension.WalletExtensionClient(_grpcChannelFactory.Create());
        }


    }
}
