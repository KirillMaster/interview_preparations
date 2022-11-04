FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Api/Dotnet.Sample.Api.csproj", "Api/"]
RUN dotnet restore "Api/Dotnet.Sample.Api.csproj"
COPY . .
WORKDIR "src/Api"
RUN dotnet build "Dotnet.Sample.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dotnet.Sample.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dotnet.Sample.Api.dll"]
