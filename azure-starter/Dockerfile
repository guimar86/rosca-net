FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["azure-starter/azure-starter.csproj", "azure-starter/"]
RUN dotnet restore "azure-starter/azure-starter.csproj"
COPY . .
WORKDIR "/src/azure-starter"
RUN dotnet build "azure-starter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "azure-starter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "azure-starter.dll"]
