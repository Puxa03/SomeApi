#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SomeApi/SomeApi.csproj", "SomeApi/"]
RUN dotnet restore "SomeApi/SomeApi.csproj"
COPY . .
WORKDIR "/src/SomeApi"
RUN dotnet build "SomeApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SomeApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SomeApi.dll"]