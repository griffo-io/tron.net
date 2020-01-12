namespace Tron.Net.Client.Grpc
{
    public class WalletSolidityClientFactory : IWalletSolidityClientFactory
    {
        private readonly IGrpcChannelFactory _channelFactory;

        public WalletSolidityClientFactory(IGrpcChannelFactory channelFactory)
        {
            _channelFactory = channelFactory;
        }

        public Protocol.WalletSolidity.WalletSolidityClient Create()
        {
            return new Protocol.WalletSolidity.WalletSolidityClient(_channelFactory.Create());
        }

    }
}
