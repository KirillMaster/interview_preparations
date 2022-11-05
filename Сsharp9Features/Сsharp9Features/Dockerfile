FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Сsharp9Features/Сsharp9Features.csproj", "Сsharp9Features/"]
RUN dotnet restore "Сsharp9Features/Сsharp9Features.csproj"
COPY . .
WORKDIR "/src/Сsharp9Features"
RUN dotnet build "Сsharp9Features.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Сsharp9Features.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Сsharp9Features.dll"]
