using System.Threading;
using System.Threading.Tasks;
using Tron.Net.Client.Grpc;
using Tron.Net.Client.Grpc.Configuration;
using Tron.Net.Protocol;

namespace Tron.Net.Client
{
    public sealed class Wallet : IWallet
    {
        private readonly IWalletClientFactory _clientFactory;
        private readonly IWalletClientCallConfiguration _configuration;

        public Wallet(IWalletClientFactory clientFactory, IWalletClientCallConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        private Protocol.Wallet.WalletClient GetWallet()
        {
            return _clientFactory.Create();
        }

        public async Task<NodeList> ListNodesAsync(CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.ListNodesAsync(new EmptyMessage(), _configuration.GetCallOptions(token));
        }

        public async Task<WitnessList> ListWitnessesAsync(CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.ListWitnessesAsync(new EmptyMessage(), _configuration.GetCallOptions(token));
        }

        public async Task<Account> GetAccountAsync(Account account, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetAccountAsync(account, _configuration.GetCallOptions(token));
        }

        public async Task<Transaction> CreateTransactionAsync(TransferContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.CreateTransactionAsync(contract, _configuration.GetCallOptions(token));
        }

        public async Task<Return> BroadcastTransactionAsync(Transaction transaction, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.BroadcastTransactionAsync(transaction, _configuration.GetCallOptions(token));
        }

        public async Task<Transaction> UpdateAccountAsync(AccountUpdateContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.UpdateAccountAsync(contract, _configuration.GetCallOptions(token));
        }

        public async Task<Transaction> VoteWitnessAccountAsync(VoteWitnessContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.VoteWitnessAccountAsync(contract, _configuration.GetCallOptions(token));
        }

        public async Task<Transaction> CreateAssetIssueAsync(AssetIssueContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.CreateAssetIssueAsync(contract, _configuration.GetCallOptions(token));
        }

        public async Task<Transaction> UpdateWitnessAsync(WitnessUpdateContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.UpdateWitnessAsync(contract, _configuration.GetCallOptions(token));
        }

        public async Task<Transaction> CreateAccountAsync(AccountCreateContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.CreateAccountAsync(contract, _configuration.GetCallOptions(token));
        }

        public async Task<Transaction> CreateWitnessAsync(WitnessCreateContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.CreateWitnessAsync(contract, _configuration.GetCallOptions(token));
        }

        public async Task<Transaction> TransferAssetAsync(TransferAssetContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.TransferAssetAsync(contract, _configuration.GetCallOptions(token));
        }

        public async Task<Transaction> ParticipateAssetIssueAsync(ParticipateAssetIssueContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.ParticipateAssetIssueAsync(contract, _configuration.GetCallOptions(token));
        }

        public async Task<Transaction> FreezeBalanceAsync(FreezeBalanceContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.FreezeBalanceAsync(contract, _configuration.GetCallOptions(token));
        }

        public async Task<Transaction> UnfreezeBalanceAsync(UnfreezeBalanceContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.UnfreezeBalanceAsync(contract, _configuration.GetCallOptions(token));
        }

        public async Task<Transaction> UnfreezeAssetAsync(UnfreezeAssetContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.UnfreezeAssetAsync(contract, _configuration.GetCallOptions(token));
        }

        public async Task<Transaction> WithdrawBalanceAsync(WithdrawBalanceContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.WithdrawBalanceAsync(contract, _configuration.GetCallOptions(token));
        }

        public async Task<Transaction> UpdateAssetAsync(UpdateAssetContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.UpdateAssetAsync(contract, _configuration.GetCallOptions(token));
        }

        public async Task<AssetIssueList> GetAssetIssueByAccountAsync(Account account, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetAssetIssueByAccountAsync(account, _configuration.GetCallOptions(token));
        }

        public async Task<AccountNetMessage> GetAccountNetAsync(Account account, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetAccountNetAsync(account, _configuration.GetCallOptions(token));
        }

        public async Task<AssetIssueContract> GetAssetIssueByNameAsync(BytesMessage message, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetAssetIssueByNameAsync(message, _configuration.GetCallOptions(token));
        }

        public async Task<Block> GetNowBlockAsync(CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetNowBlockAsync(new EmptyMessage(), _configuration.GetCallOptions(token));
        }

        public async Task<Block> GetBlockByNumAsync(NumberMessage message, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetBlockByNumAsync(message, _configuration.GetCallOptions(token));
        }

        public async Task<Block> GetBlockByIdAsync(BytesMessage message, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetBlockByIdAsync(message, _configuration.GetCallOptions(token));
        }

        public async Task<BlockList> GetBlockByLimitNextAsync(BlockLimit blockLimit, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetBlockByLimitNextAsync(blockLimit, _configuration.GetCallOptions(token));
        }

        public async Task<BlockList> GetBlockByLatestNumAsync(NumberMessage message, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetBlockByLatestNumAsync(message, _configuration.GetCallOptions(token));
        }

        public async Task<Transaction> GetTransactionByIdAsync(BytesMessage message, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetTransactionByIdAsync(message, _configuration.GetCallOptions(token));
        }

        public async Task<AssetIssueList> GetAssetIssueListAsync(CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetAssetIssueListAsync(new EmptyMessage(), _configuration.GetCallOptions(token));
        }

        public async Task<NumberMessage> TotalTransactionAsync(CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.TotalTransactionAsync(new EmptyMessage(), _configuration.GetCallOptions(token));
        }

        public async Task<NumberMessage> GetNextMaintenanceTimeAsync(CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetNextMaintenanceTimeAsync(new EmptyMessage(), _configuration.GetCallOptions(token));
        }
    }
}
