namespace Tron.Net.Client.Grpc
{
    public class WalletClientFactory : IWalletClientFactory
    {
        private readonly IGrpcChannelFactory _grpcChannelFactory;

        public WalletClientFactory(IGrpcChannelFactory grpcChannelFactory)
        {
            _grpcChannelFactory = grpcChannelFactory;
        }

        public Protocol.Wallet.WalletClient Create()
        {
            return new Protocol.Wallet.WalletClient(_grpcChannelFactory.Create());
        }

    }
}