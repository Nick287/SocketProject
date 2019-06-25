#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.1-runtime-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 9000

FROM microsoft/dotnet:2.1-sdk-nanoserver-1809 AS build
WORKDIR /src
COPY /TcpListener.csproj TcpListener/
RUN dotnet restore TcpListener/TcpListener.csproj
COPY . .

FROM build AS publish
RUN dotnet publish TcpListener.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TcpListener.dll"]
