namespace Tron.Net.Client
{
    using System.Threading;
    using System.Threading.Tasks;
    using Tron.Net.Protocol;

    public interface IWallet
    {
        Task<NodeList> ListNodesAsync(CancellationToken token = default);

        Task<WitnessList> ListWitnessesAsync(CancellationToken token = default);

        Task<Account> GetAccountAsync(Account account, CancellationToken token = default);

        Task<Transaction> CreateTransactionAsync(TransferContract contract, CancellationToken token = default);

        Task<Return> BroadcastTransactionAsync(Transaction transaction, CancellationToken token = default);

        Task<Transaction> UpdateAccountAsync(AccountUpdateContract contract, CancellationToken token = default);

        Task<Transaction> VoteWitnessAccountAsync(VoteWitnessContract contract, CancellationToken token = default);

        Task<Transaction> CreateAssetIssueAsync(AssetIssueContract contract, CancellationToken token = default);

        Task<Transaction> UpdateWitnessAsync(WitnessUpdateContract contract, CancellationToken token = default);

        Task<Transaction> CreateAccountAsync(AccountCreateContract contract, CancellationToken token = default);
        
        Task<Transaction> CreateWitnessAsync(WitnessCreateContract contract, CancellationToken token = default);
        
        Task<Transaction> TransferAssetAsync(TransferAssetContract contract, CancellationToken token = default);
        
        Task<Transaction> ParticipateAssetIssueAsync(ParticipateAssetIssueContract contract, CancellationToken token = default);
        
        Task<Transaction> FreezeBalanceAsync(FreezeBalanceContract contract, CancellationToken token = default);
        
        Task<Transaction> UnfreezeBalanceAsync(UnfreezeBalanceContract contract, CancellationToken token = default);
        
        Task<Transaction> UnfreezeAssetAsync(UnfreezeAssetContract contract, CancellationToken token = default);
        
        Task<Transaction> WithdrawBalanceAsync(WithdrawBalanceContract contract, CancellationToken token = default);
        
        Task<Transaction> UpdateAssetAsync(UpdateAssetContract contract, CancellationToken token = default);
        
        Task<AssetIssueList> GetAssetIssueByAccountAsync(Account account, CancellationToken token = default);
        
        Task<AccountNetMessage> GetAccountNetAsync(Account account, CancellationToken token = default);
        
        Task<AssetIssueContract> GetAssetIssueByNameAsync(BytesMessage message, CancellationToken token = default);
        
        Task<Block> GetNowBlockAsync(CancellationToken token = default);
        
        Task<Block> GetBlockByNumAsync(NumberMessage message, CancellationToken token = default);
        
        Task<Block> GetBlockByIdAsync(BytesMessage message, CancellationToken token = default);
        
        Task<BlockList> GetBlockByLimitNextAsync(BlockLimit blockLimit, CancellationToken token = default);
        
        Task<BlockList> GetBlockByLatestNumAsync(NumberMessage message, CancellationToken token = default);
        
        Task<Transaction> GetTransactionByIdAsync(BytesMessage message, CancellationToken token = default);
        
        Task<AssetIssueList> GetAssetIssueListAsync(CancellationToken token = default);
        
        Task<NumberMessage> TotalTransactionAsync(CancellationToken token = default);
        
        Task<NumberMessage> GetNextMaintenanceTimeAsync(CancellationToken token = default);

    }
}
