#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ecommerce-item-api/ecommerce-item-api.csproj", "ecommerce-item-api/"]
RUN dotnet restore "ecommerce-item-api/ecommerce-item-api.csproj"
COPY . .
WORKDIR "/src/ecommerce-item-api"
RUN dotnet build "ecommerce-item-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ecommerce-item-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ecommerce-item-api.dll"]