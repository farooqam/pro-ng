FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY SportsStoreApi/SportsStoreApi.csproj SportsStoreApi/
COPY SportsStore.DataAccess.Ef/SportsStore.DataAccess.Ef.csproj SportsStore.DataAccess.Ef/
COPY SportsStoreApi.DataAccess/SportsStoreApi.DataAccess.csproj SportsStoreApi.DataAccess/
COPY SportsStoreApi.DataAccess.Ef.SeedData/SportsStoreApi.DataAccess.Ef.SeedData.csproj SportsStoreApi.DataAccess.Ef.SeedData/
RUN dotnet restore
COPY . .
WORKDIR /src/SportsStoreApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SportsStoreApi.dll"]
