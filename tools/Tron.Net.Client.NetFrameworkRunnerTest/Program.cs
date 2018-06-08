using System;

using Tron.Net.Client.Grpc;
using Tron.Net.Client.Grpc.Configuration;
using Tron.Net.Client.NetFrameworkRunnerTest.Configuration;

namespace Tron.Net.Client.NetFrameworkRunnerTest
{
    class Program
    {
        static void Main(string[] args)
        {var configuration = new AppSettingsChannelConfiguration();
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
