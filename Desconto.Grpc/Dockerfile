#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Desconto.Grpc/Desconto.Grpc.csproj", "Desconto.Grpc/"]
RUN dotnet restore "Desconto.Grpc/Desconto.Grpc.csproj"
COPY . .
WORKDIR "/src/Desconto.Grpc"
RUN dotnet build "Desconto.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Desconto.Grpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Desconto.Grpc.dll"]
