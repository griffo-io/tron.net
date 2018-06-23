[![Build status](https://ci.appveyor.com/api/projects/status/6a01tofdfbrrlrsf?svg=true)](https://ci.appveyor.com/project/dariogriffo/tron-net)
[![NuGet](https://img.shields.io/nuget/v/griffo-io.svg?style=flat)](https://www.nuget.org/packages/Tron.Net.Client/) 
[![GitHub license](https://img.shields.io/github/license/griffo-io/tron.net.svg)](https://github.com/griffo-io/tron.net/blob/master/LICENSE)


# tron.net

[![N|Solid](https://avatars2.githubusercontent.com/u/39886363?s=200&v=4)](https://github.com/griffo-io/tron.net)

Tron.Net is a port in .NET standard of the [Tron protocol](https://github.com/tronprotocol/)

###### This library is still in experimental mode, use it with discretion, suggestions and PR are welcome.

## Downloads ##

The latest stable release of the Tron.Net.Client [available on NuGet](https://www.nuget.org/packages/Tron.Net.Client)

The latest stable release of the Tron.Net.Protocol [available on NuGet](https://www.nuget.org/packages/Tron.Net.Protocol)

# How to use it

  - You can download the Tron.Net.Client package, implement the `IChannelConfiguration` interface, and use the implementation of the different services avaiable:
 
 -- `IWallet`

 -- `IWalletExtension`

 -- `IWalletSolidity`
  
  or
 
 - You can download the Tron.Net.Protocol and create your own library to interact with the Tron Network using the Tron.Net.Protocol.Api.Grpc generated clients

# Examples

You can find in the tools folder 2 projects:
  - Tron.Net.Client.NetCoreRunnerTest a simple dotnet core application that connects to a local node that contains an example with a JSON configuration
  - Tron.Net.Client.Tron.Net.Client.NetFrameworkRunnerTest a simple dotnet framework 4.7 application that connects to a local node that contains an example with a configuration via AppSettings

# Advanced configuration

Tron.Net.Client is built upon the premise of flexibility, so the following interfaces to configure timeouts and Options for the respective grpc calls can be customised:

-- `IWalletCallConfiguration`

-- `IWalletExtensionCallConfiguration`

-- `IWalletSolidityClientCallConfiguration`

If using a DI framework like Autofac with assembly discovery, make sure to override the registration of `AllClientsDefaultCallConfiguration` which has a 10 seconds timeout by default

Logo Provided by [Vecteezy](https://vecteezy.com)
