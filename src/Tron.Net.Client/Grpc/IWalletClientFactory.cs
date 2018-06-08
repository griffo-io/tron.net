using System.Threading;
using Grpc.Core;

namespace Tron.Net.Client.Grpc
{
    public interface IWalletClientFactory
    {
        Protocol.Wallet.WalletClient Create();

        CallOptions GetCallOptions(CancellationToken cancellationToken);

    }
}