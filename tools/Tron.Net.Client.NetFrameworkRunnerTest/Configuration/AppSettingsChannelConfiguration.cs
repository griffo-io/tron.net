using System;
using System.IO;
using Tron.Net.Client.Grpc.Configuration;

namespace Tron.Net.Client.NetFrameworkRunnerTest.Configuration
{
    internal class AppSettingsChannelConfiguration : IChannelConfiguration
    {
        private const string PortKey = "port";
        private const string HostKey = "host";
        private const string MaxConcurrentStreamsKey = "maxConcurrentStreams";
        private const string TimeOutMsKey = "timeOutMs";
        
        public AppSettingsChannelConfiguration()
        {
            Host = System.Configuration.ConfigurationManager.AppSettings[HostKey];
            Port = int.Parse(System.Configuration.ConfigurationManager.AppSettings[PortKey]);
            var maxConcurrentStreams = System.Configuration.ConfigurationManager.AppSettings[MaxConcurrentStreamsKey];
            var timeOutMs = System.Configuration.ConfigurationManager.AppSettings[TimeOutMsKey];
            if (string.IsNullOrWhiteSpace(maxConcurrentStreams) == false)
            {
                MaxConcurrentStreams = int.Parse(maxConcurrentStreams);
            }

            if (string.IsNullOrWhiteSpace(timeOutMs) == false)
            {
                TimeOutMs = TimeSpan.FromMilliseconds(int.Parse(timeOutMs));
            }

        }

        public int Port { get; }

        public string Host { get; }

        public int? MaxConcurrentStreams { get; }

        public TimeSpan? TimeOutMs { get; }

    }
}
