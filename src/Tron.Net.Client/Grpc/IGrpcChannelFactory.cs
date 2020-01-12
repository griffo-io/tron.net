namespace Tron.Net.Client.Grpc
{
    public interface IGrpcChannelFactory
    {
        global::Grpc.Core.Channel Create();
    }
}
