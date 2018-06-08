# tron.net

[![N|Solid](https://avatars2.githubusercontent.com/u/39886363?s=200&v=4)](https://github.com/griffo-io/tron.net)

Tron.Net is a port in .NET standard of the Tron protocol.

## Downloads ##

The latest stable release of the Tron.Net.Client [available on NuGet](https://www.nuget.org/packages/Tron.Net.Client)
The latest stable release of the Tron.Net.Protocol [available on NuGet](https://www.nuget.org/packages/Tron.Net.Protocol)

# How to use it

  - You can download the Tron.Net.Client package, implement the `IChannelConfiguration` interface, and use the implementation of the different services avaiable:
 
 -- `IWallet`
  
  or
 
 - You can download the Tron.Net.Protocol and create your own library to interact with the Tron Network using the Tron.Api.Grpc generated clients

# Examples

You can find in the tools folder 2 projects:
  - Tron.Net.Client.NetCoreRunnerTest a simple dotnet core application that connects to a local node that contains an example with a JSON configuration
  - Tron.Net.Client.Tron.Net.Client.NetFrameworkRunnerTest a simple dotnet framework 4.7 application that connects to a local node that contains an example with a configuration via AppSettings
