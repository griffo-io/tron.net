using System.Threading;
using System.Threading.Tasks;
using Tron.Net.Client.Grpc;
using Tron.Net.Client.Grpc.Configuration;
using Tron.Net.Protocol;

namespace Tron.Net.Client
{
    public class WalletExtension : IWalletExtension
    {
        private readonly IWalletExtensionClientFactory _clientFactory;
        private readonly IWalletExtensionCallConfiguration _configuration;

        public WalletExtension(IWalletExtensionClientFactory clientFactory, IWalletExtensionCallConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }


        private Protocol.WalletExtension.WalletExtensionClient GetWalletExtension()
        {
            return _clientFactory.Create();
        }

        public async Task<TransactionList> GetTransactionsFromThisAsync(AccountPaginated accountPagination, CancellationToken token = default(CancellationToken))
        {
            var walletExtension = GetWalletExtension();
            return await walletExtension.GetTransactionsFromThisAsync(accountPagination, _configuration.GetCallOptions(token));
        }

        public async Task<TransactionList> GetTransactionsToThisAsync(AccountPaginated accountPagination, CancellationToken token = default(CancellationToken))
        {
            var walletExtension = GetWalletExtension();
            return await walletExtension.GetTransactionsToThisAsync(accountPagination, _configuration.GetCallOptions(token));
        }
    }
}
