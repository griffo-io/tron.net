using System;
using Tron.Net.Client.Grpc;
using Tron.Net.Client.Test.Configuration;

namespace Tron.Net.Client.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new JsonChannelConfiguration();
            IWallet wallet = new Wallet(new ChannelFactory(configuration));
            var nodes = wallet.ListNodes().GetAwaiter().GetResult();

            foreach (var node in nodes.Nodes)
            {
                Console.WriteLine($"Node: {node.Address}");    
            }

            
        }
    }
}
