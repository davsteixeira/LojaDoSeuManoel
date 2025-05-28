FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LojaDoSeuManoel/LojaDoSeuManoel.csproj", "LojaDoSeuManoel/"]
RUN dotnet restore "LojaDoSeuManoel/LojaDoSeuManoel.csproj"
COPY . .
WORKDIR "/src/LojaDoSeuManoel"
RUN dotnet build "LojaDoSeuManoel.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LojaDoSeuManoel.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LojaDoSeuManoel.dll"]
