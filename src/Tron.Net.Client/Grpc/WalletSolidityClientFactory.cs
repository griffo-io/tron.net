namespace Tron.Net.Client.Grpc
{
    public class WalletSolidityClientFactory : IWalletSolidityClientFactory
    {
        private readonly IGrpcChannelFactory _grpcChannelFactory;

        public WalletSolidityClientFactory(IGrpcChannelFactory grpcChannelFactory)
        {
            _grpcChannelFactory = grpcChannelFactory;
        }

        public Protocol.WalletSolidity.WalletSolidityClient Create()
        {
            return new Protocol.WalletSolidity.WalletSolidityClient(_grpcChannelFactory.Create());
        }

    }
}