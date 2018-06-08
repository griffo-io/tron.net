using System.Threading;
using System.Threading.Tasks;
using Tron.Net.Client.Grpc;
using Tron.Net.Protocol;

namespace Tron.Net.Client
{
    public sealed class Wallet : IWallet
    {
        private readonly IWalletClientFactory _clientFactory;

        public Wallet(IWalletClientFactory clientFactory)
        {            
            _clientFactory = clientFactory;
        }

        private Protocol.Wallet.WalletClient GetWallet()
        {
            return _clientFactory.Create();
        }

        public async Task<NodeList> ListNodesAsync(CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.ListNodesAsync(new EmptyMessage(), _clientFactory.GetCallOptions(token));
        }

        public async Task<WitnessList> ListWitnessesAsync(CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.ListWitnessesAsync(new EmptyMessage(), _clientFactory.GetCallOptions(token));
        }

        public async Task<Account> GetAccountAsync(Account account, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetAccountAsync(account, _clientFactory.GetCallOptions(token));
        }

        public async Task<Transaction> CreateTransactionAsync(TransferContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.CreateTransactionAsync(contract, _clientFactory.GetCallOptions(token));
        }

        public async Task<Return> BroadcastTransactionAsync(Transaction transaction, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.BroadcastTransactionAsync(transaction, _clientFactory.GetCallOptions(token));
        }

        public async Task<Transaction> UpdateAccountAsync(AccountUpdateContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.UpdateAccountAsync(contract, _clientFactory.GetCallOptions(token));
        }

        public async Task<Transaction> VoteWitnessAccountAsync(VoteWitnessContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.VoteWitnessAccountAsync(contract, _clientFactory.GetCallOptions(token));
        }

        public async Task<Transaction> CreateAssetIssueAsync(AssetIssueContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.CreateAssetIssueAsync(contract, _clientFactory.GetCallOptions(token));
        }

        public async Task<Transaction> UpdateWitnessAsync(WitnessUpdateContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.UpdateWitnessAsync(contract, _clientFactory.GetCallOptions(token));
        }

        public async Task<Transaction> CreateAccountAsync(AccountCreateContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.CreateAccountAsync(contract, _clientFactory.GetCallOptions(token));
        }

        public async Task<Transaction> CreateWitnessAsync(WitnessCreateContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.CreateWitnessAsync(contract, _clientFactory.GetCallOptions(token));
        }

        public async Task<Transaction> TransferAssetAsync(TransferAssetContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.TransferAssetAsync(contract, _clientFactory.GetCallOptions(token));
        }

        public async Task<Transaction> ParticipateAssetIssueAsync(ParticipateAssetIssueContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.ParticipateAssetIssueAsync(contract, _clientFactory.GetCallOptions(token));
        }

        public async Task<Transaction> FreezeBalanceAsync(FreezeBalanceContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.FreezeBalanceAsync(contract, _clientFactory.GetCallOptions(token));
        }

        public async Task<Transaction> UnfreezeBalanceAsync(UnfreezeBalanceContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.UnfreezeBalanceAsync(contract, _clientFactory.GetCallOptions(token));
        }

        public async Task<Transaction> UnfreezeAssetAsync(UnfreezeAssetContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.UnfreezeAssetAsync(contract, _clientFactory.GetCallOptions(token));
        }

        public async Task<Transaction> WithdrawBalanceAsync(WithdrawBalanceContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.WithdrawBalanceAsync(contract, _clientFactory.GetCallOptions(token));
        }

        public async Task<Transaction> UpdateAssetAsync(UpdateAssetContract contract, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.UpdateAssetAsync(contract, _clientFactory.GetCallOptions(token));
        }

        public async Task<AssetIssueList> GetAssetIssueByAccountAsync(Account account, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetAssetIssueByAccountAsync(account, _clientFactory.GetCallOptions(token));
        }

        public async Task<AccountNetMessage> GetAccountNetAsync(Account account, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetAccountNetAsync(account, _clientFactory.GetCallOptions(token));
        }

        public async Task<AssetIssueContract> GetAssetIssueByNameAsync(BytesMessage message, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetAssetIssueByNameAsync(message, _clientFactory.GetCallOptions(token));
        }

        public async Task<Block> GetNowBlockAsync(CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetNowBlockAsync(new EmptyMessage(), _clientFactory.GetCallOptions(token));
        }

        public async Task<Block> GetBlockByNumAsync(NumberMessage message, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetBlockByNumAsync(message, _clientFactory.GetCallOptions(token));
        }

        public async Task<Block> GetBlockByIdAsync(BytesMessage message, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetBlockByIdAsync(message, _clientFactory.GetCallOptions(token));
        }

        public async Task<BlockList> GetBlockByLimitNextAsync(BlockLimit blockLimit, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetBlockByLimitNextAsync(blockLimit, _clientFactory.GetCallOptions(token));
        }

        public async Task<BlockList> GetBlockByLatestNumAsync(NumberMessage message, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetBlockByLatestNumAsync(message, _clientFactory.GetCallOptions(token));
        }

        public async Task<Transaction> GetTransactionByIdAsync(BytesMessage message, CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetTransactionByIdAsync(message, _clientFactory.GetCallOptions(token));
        }

        public async Task<AssetIssueList> GetAssetIssueListAsync(CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetAssetIssueListAsync(new EmptyMessage(), _clientFactory.GetCallOptions(token));
        }

        public async Task<NumberMessage> TotalTransactionAsync(CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.TotalTransactionAsync(new EmptyMessage(), _clientFactory.GetCallOptions(token));
        }

        public async Task<NumberMessage> GetNextMaintenanceTimeAsync(CancellationToken token = default(CancellationToken))
        {
            var wallet = GetWallet();
            return await wallet.GetNextMaintenanceTimeAsync(new EmptyMessage(), _clientFactory.GetCallOptions(token));
        }
    }
}
