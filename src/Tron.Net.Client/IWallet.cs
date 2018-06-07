using System.Threading;
using System.Threading.Tasks;
using Tron.Net.Protocol;

namespace Tron.Net.Client
{
    public interface IWallet
    {
        Task<NodeList> ListNodes(CancellationToken token = default(CancellationToken));

        Task<WitnessList> ListWitnesses(CancellationToken token = default(CancellationToken));
    }
}
