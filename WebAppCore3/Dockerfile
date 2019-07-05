FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["WebAppCore3/WebAppCore3.csproj", "WebAppCore3/"]
RUN dotnet restore "WebAppCore3/WebAppCore3.csproj"
COPY . .
WORKDIR "/src/WebAppCore3"
RUN dotnet build "WebAppCore3.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebAppCore3.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebAppCore3.dll"]