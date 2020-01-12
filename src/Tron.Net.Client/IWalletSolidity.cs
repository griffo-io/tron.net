namespace Tron.Net.Client
{
    using System.Threading;
    using System.Threading.Tasks;
    using Tron.Net.Protocol;

    public interface IWalletSolidity
    {
        Task<Account> GetAccountAsync(Account account, CancellationToken token = default);

        Task<WitnessList> ListWitnessesAsync(CancellationToken token = default);

        Task<AssetIssueList> GetAssetIssueListAsync(CancellationToken token = default);

        Task<Block> GetNowBlockAsync(CancellationToken token = default);

        Task<Block> GetBlockByNumAsync(NumberMessage message, CancellationToken token = default);

    }
}
