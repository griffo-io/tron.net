using System;
using Tron.Net.Client.Grpc;
using Tron.Net.Client.Grpc.Configuration;
using Tron.Net.Client.NetCoreRunnerTest.Configuration;

namespace Tron.Net.Client.NetCoreRunnerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new JsonChannelConfiguration();
            var grpcChanngelFactory = new GrpcGrpcChannelFactory(configuration);
            var walletClientFactory = new WalletClientFactory(grpcChanngelFactory);
            var wallet = new Wallet(walletClientFactory, new AllClientsDefaultCallConfiguration());

            var nodes = wallet.ListNodesAsync().GetAwaiter().GetResult();

            foreach (var node in nodes.Nodes)
            {
                Console.WriteLine($"Node: {node.Address}");    
            }

            
        }
    }
}
