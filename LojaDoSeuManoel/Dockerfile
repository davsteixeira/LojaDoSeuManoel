FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Embalagem.API/Embalagem.API.csproj", "Embalagem.API/"]
RUN dotnet restore "Embalagem.API/Embalagem.API.csproj"
COPY . .
WORKDIR "/src/Embalagem.API"
RUN dotnet build "Embalagem.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Embalagem.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Embalagem.API.dll"]
