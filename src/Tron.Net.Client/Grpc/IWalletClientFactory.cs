namespace Tron.Net.Client.Grpc
{
    public interface IWalletClientFactory
    {
        Protocol.Wallet.WalletClient Create();
    }
}