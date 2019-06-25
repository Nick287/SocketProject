#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.2-runtime-nanoserver-1803 AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY TcpClient/TcpClient.csproj TcpClient/
RUN dotnet restore TcpClient/TcpClient.csproj
COPY . .
WORKDIR /src/TcpClient
RUN dotnet build TcpClient.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TcpClient.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TcpClient.dll"]
