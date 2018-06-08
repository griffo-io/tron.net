using System.Threading;
using System.Threading.Tasks;
using Tron.Net.Protocol;

namespace Tron.Net.Client
{
    public interface IWallet
    {
        Task<NodeList> ListNodesAsync(CancellationToken token = default(CancellationToken));

        Task<WitnessList> ListWitnessesAsync(CancellationToken token = default(CancellationToken));

        Task<Account> GetAccountAsync(Account account, CancellationToken token = default(CancellationToken));

        Task<Transaction> CreateTransactionAsync(TransferContract contract, CancellationToken token = default(CancellationToken));

        Task<Return> BroadcastTransactionAsync(Transaction transaction, CancellationToken token = default(CancellationToken));

        Task<Transaction> UpdateAccountAsync(AccountUpdateContract contract, CancellationToken token = default(CancellationToken));

        Task<Transaction> VoteWitnessAccountAsync(VoteWitnessContract contract, CancellationToken token = default(CancellationToken));

        Task<Transaction> CreateAssetIssueAsync(AssetIssueContract contract, CancellationToken token = default(CancellationToken));

        Task<Transaction> UpdateWitnessAsync(WitnessUpdateContract contract, CancellationToken token = default(CancellationToken));

        Task<Transaction> CreateAccountAsync(AccountCreateContract contract, CancellationToken token = default(CancellationToken));
        
        Task<Transaction> CreateWitnessAsync(WitnessCreateContract contract, CancellationToken token = default(CancellationToken));
        
        Task<Transaction> TransferAssetAsync(TransferAssetContract contract, CancellationToken token = default(CancellationToken));
        
        Task<Transaction> ParticipateAssetIssueAsync(ParticipateAssetIssueContract contract, CancellationToken token = default(CancellationToken));
        
        Task<Transaction> FreezeBalanceAsync(FreezeBalanceContract contract, CancellationToken token = default(CancellationToken));
        
        Task<Transaction> UnfreezeBalanceAsync(UnfreezeBalanceContract contract, CancellationToken token = default(CancellationToken));
        
        Task<Transaction> UnfreezeAssetAsync(UnfreezeAssetContract contract, CancellationToken token = default(CancellationToken));
        
        Task<Transaction> WithdrawBalanceAsync(WithdrawBalanceContract contract, CancellationToken token = default(CancellationToken));
        
        Task<Transaction> UpdateAssetAsync(UpdateAssetContract contract, CancellationToken token = default(CancellationToken));
        
        Task<AssetIssueList> GetAssetIssueByAccountAsync(Account account, CancellationToken token = default(CancellationToken));
        
        Task<AccountNetMessage> GetAccountNetAsync(Account account, CancellationToken token = default(CancellationToken));
        
        Task<AssetIssueContract> GetAssetIssueByNameAsync(BytesMessage message, CancellationToken token = default(CancellationToken));
        
        Task<Block> GetNowBlockAsync(CancellationToken token = default(CancellationToken));
        
        Task<Block> GetBlockByNumAsync(NumberMessage message, CancellationToken token = default(CancellationToken));
        
        Task<Block> GetBlockByIdAsync(BytesMessage message, CancellationToken token = default(CancellationToken));
        
        Task<BlockList> GetBlockByLimitNextAsync(BlockLimit blockLimit, CancellationToken token = default(CancellationToken));
        
        Task<BlockList> GetBlockByLatestNumAsync(NumberMessage message, CancellationToken token = default(CancellationToken));
        
        Task<Transaction> GetTransactionByIdAsync(BytesMessage message, CancellationToken token = default(CancellationToken));
        
        Task<AssetIssueList> GetAssetIssueListAsync(CancellationToken token = default(CancellationToken));
        
        Task<NumberMessage> TotalTransactionAsync(CancellationToken token = default(CancellationToken));
        
        Task<NumberMessage> GetNextMaintenanceTimeAsync(CancellationToken token = default(CancellationToken));

    }
}
