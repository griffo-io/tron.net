namespace Tron.Net.Client.Grpc
{
    public interface IWalletSolidityClientFactory
    {
        Protocol.WalletSolidity.WalletSolidityClient Create();
    }
}