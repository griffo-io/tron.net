using System.Threading;
using Grpc.Core;

namespace Tron.Net.Client.Grpc
{
    public interface IGrpcChannelFactory
    {
        Channel Create();

    }
}
