using System.Threading;
using Grpc.Core;

namespace Tron.Net.Client.Grpc
{
    public interface IChannelFactory
    {
        Channel CreateChannel();

        CallOptions GetCallOptions(CancellationToken cancellationToken);

    }
}
