using System.Threading;
using System.Threading.Tasks;
using Tron.Net.Protocol;

namespace Tron.Net.Client
{
    public interface IWalletSolidity
    {
        Task<Account> GetAccountAsync(Account account, CancellationToken token = default(CancellationToken));

        Task<WitnessList> ListWitnessesAsync(CancellationToken token = default(CancellationToken));

        Task<AssetIssueList> GetAssetIssueListAsync(CancellationToken token = default(CancellationToken));

        Task<Block> GetNowBlockAsync(CancellationToken token = default(CancellationToken));

        Task<Block> GetBlockByNumAsync(NumberMessage message, CancellationToken token = default(CancellationToken));

    }
}