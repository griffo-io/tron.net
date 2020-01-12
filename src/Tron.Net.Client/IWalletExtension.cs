namespace Tron.Net.Client
{
    using System.Threading;
    using System.Threading.Tasks;
    using Tron.Net.Protocol;

    public interface IWalletExtension
    {
        Task<TransactionList> GetTransactionsFromThisAsync(AccountPaginated accountPagination, CancellationToken token = default);

        Task<TransactionList> GetTransactionsToThisAsync(AccountPaginated accountPagination, CancellationToken token = default);
    }
}
