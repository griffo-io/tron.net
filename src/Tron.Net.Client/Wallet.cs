using System.Threading;
using System.Threading.Tasks;
using Tron.Net.Client.Grpc;
using Tron.Net.Protocol;

namespace Tron.Net.Client
{
    public sealed class Wallet : IWallet
    {
        private readonly IChannelFactory _channelFactory;

        public Wallet(IChannelFactory channelFactory)
        {
            _channelFactory = channelFactory;
        }

        private Protocol.Wallet.WalletClient GetWallet()
        {
            var channel = _channelFactory.CreateChannel();
            var wallet = new Protocol.Wallet.WalletClient(channel);
            return wallet;
        }
      
        public async Task<NodeList> ListNodes(CancellationToken token)
        {
            return await GetWallet().ListNodesAsync(new EmptyMessage(), _channelFactory.GetCallOptions(token));
        }

        public async Task<WitnessList> ListWitnesses(CancellationToken token)
        {
            return await GetWallet().ListWitnessesAsync(new EmptyMessage(), _channelFactory.GetCallOptions(token));
        }
        
    }
}
