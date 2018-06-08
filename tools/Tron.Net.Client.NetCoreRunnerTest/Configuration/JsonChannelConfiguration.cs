using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Tron.Net.Client.Grpc.Configuration;

namespace Tron.Net.Client.NetCoreRunnerTest.Configuration
{
    internal class JsonChannelConfiguration : IChannelConfiguration
    {
        private const string TronElement = "Tron:";
        private const string NetworkElement = "Network:";
        private const string MainNodeElement = "Node:";
        private const string PortKey = "Port";
        private const string HostKey = "Host";
        private const string MaxConcurrentStreamsKey = "MaxConcurrentStreams";
        private const string TimeOutMsKey = "TimeOutMs";
        private const string DefaultTimeOutMs = "30000";

        public JsonChannelConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var networkKey = $"{TronElement}{NetworkElement}";
            var mainNodeKey = $"{networkKey}{MainNodeElement}";
            Host = configuration[$"{mainNodeKey}{HostKey}"];
            Port = int.Parse(configuration[$"{mainNodeKey}{PortKey}"]);

            var maxConcurrentStreamsConfigured = configuration[$"{networkKey}{MaxConcurrentStreamsKey}"];
            if (string.IsNullOrEmpty(maxConcurrentStreamsConfigured) == false)
            {
                MaxConcurrentStreams = int.Parse(maxConcurrentStreamsConfigured);
            }

            var timeOutConfigured = configuration[$"{networkKey}{TimeOutMsKey}"];
            if (string.IsNullOrEmpty(timeOutConfigured) == false)
            {
                timeOutConfigured = DefaultTimeOutMs;
            }
            TimeOutMs = TimeSpan.FromMilliseconds(int.Parse(timeOutConfigured));
        }

        public int Port { get; }
        
        public string Host { get; }
        
        public int? MaxConcurrentStreams { get; }
        
        public TimeSpan? TimeOutMs { get; }

    }
}
