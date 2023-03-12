FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000
ENV SWAGGER_FILE_URL http://localhost:5000/swagger/v1/swagger.json
ENV ASPNETCORE_URLS=http://+:5000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["azure-starter/azure-starter.csproj", "azure-starter/"]
RUN dotnet restore "azure-starter/azure-starter.csproj"
COPY . .
WORKDIR "/src/azure-starter"
RUN dotnet build "azure-starter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "azure-starter.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "azure-starter.dll"]
