#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ecommerce-cart-api/ecommerce-cart-api.csproj", "ecommerce-cart-api/"]
RUN dotnet restore "ecommerce-cart-api/ecommerce-cart-api.csproj"
COPY . .
WORKDIR "/src/ecommerce-cart-api"
RUN dotnet build "ecommerce-cart-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ecommerce-cart-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ecommerce-cart-api.dll"]