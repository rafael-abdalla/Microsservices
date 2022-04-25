#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Desconto.Api/Desconto.Api.csproj", "Desconto.Api/"]
RUN dotnet restore "Desconto.Api/Desconto.Api.csproj"
COPY . .
WORKDIR "/src/Desconto.Api"
RUN dotnet build "Desconto.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Desconto.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Desconto.Api.dll"]
