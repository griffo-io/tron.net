set SolutionDir=%1
set SolutionDir=%SolutionDir:"=%

set ProjectDir=%2
set ProjectDir=%ProjectDir:"=%

set NuGetPackageRoot=%3
set NuGetPackageRoot=%NuGetPackageRoot:"=%

set GoogleProtobufToolsVersion=%4
set GoogleProtobufToolsVersion=%GoogleProtobufToolsVersion:"=%

set GrpcToolsVersion=%5
set GrpcToolsVersion=%GrpcToolsVersion:"=%

set ProtosRootDir=%6
set ProtosRootDir=%ProtosRootDir:"=%

set ProtobufProtocDir="%NuGetPackageRoot%google.protobuf.tools\%GoogleProtobufToolsVersion%\tools\windows_x64\"
set ProtobufProtocDir=%ProtobufProtocDir:"=%

set GrpcProtocDir="%NuGetPackageRoot%grpc.tools\%GrpcToolsVersion%\tools\windows_x64\"
set GrpcProtocDir=%GrpcProtocDir:"=%

set TronprotocolProtosDir="%ProtosRootDir%\tronprotocol"
set TronprotocolProtosDir=%TronprotocolProtosDir:"=%

set ProtocolNamespace=Tron.Net.Protocol

																												  
"%ProtobufProtocDir%protoc.exe" -I="%ProtosRootDir%" -I="%ProtosRootDir%\protobuf\src" -I="%TronprotocolProtosDir%" --csharp_out="%ProjectDir%Core" "%TronprotocolProtosDir%\core\Tron.proto"
"%ProtobufProtocDir%protoc.exe" -I="%ProtosRootDir%" -I="%ProtosRootDir%\protobuf\src" -I="%TronprotocolProtosDir%" --csharp_out="%ProjectDir%Core" "%TronprotocolProtosDir%\core\Contract.proto"
"%ProtobufProtocDir%protoc.exe" -I="%ProtosRootDir%" -I="%ProtosRootDir%\protobuf\src" -I="%TronprotocolProtosDir%" --csharp_out="%ProjectDir%Core" "%TronprotocolProtosDir%\core\Discover.proto"
"%ProtobufProtocDir%protoc.exe" -I="%ProtosRootDir%" -I="%ProtosRootDir%\protobuf\src" -I="%TronprotocolProtosDir%" --csharp_out="%ProjectDir%Core" "%TronprotocolProtosDir%\core\TronInventoryItems.proto"
"%ProtobufProtocDir%protoc.exe" -I="%ProtosRootDir%" -I="%ProtosRootDir%\protobuf\src" -I="%TronprotocolProtosDir%" -I="%ProtosRootDir%\googleapis" --csharp_out="%ProjectDir%Api"  "%TronprotocolProtosDir%\api\api.proto"
																		   
"%GrpcProtocDir%protoc.exe" -I="%ProtosRootDir%" -I="%ProtosRootDir%\protobuf\src" -I="%ProtosRootDir%\googleapis" -I="%TronprotocolProtosDir%" --plugin=protoc-gen-grpc="%GrpcProtocDir%grpc_csharp_plugin.exe" --grpc_out="%ProjectDir%Api" "%TronprotocolProtosDir%\api\api.proto"

