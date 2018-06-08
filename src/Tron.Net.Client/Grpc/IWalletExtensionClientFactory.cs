namespace Tron.Net.Client.Grpc
{
    public interface IWalletExtensionClientFactory
    {
        Protocol.WalletExtension.WalletExtensionClient Create();
    }
}
