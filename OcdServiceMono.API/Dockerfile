#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["OcdServiceMono.API/OcdServiceMono.API.csproj", "OcdServiceMono.API/"]
RUN dotnet restore "OcdServiceMono.API/OcdServiceMono.API.csproj"
COPY . .
WORKDIR "/src/OcdServiceMono.API"
RUN dotnet build "OcdServiceMono.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OcdServiceMono.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OcdServiceMono.API.dll"]