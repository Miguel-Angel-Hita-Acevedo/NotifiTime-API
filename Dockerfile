FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 5004

ENV ASPNETCORE_URLS=http://+:5004

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG configuration=Release
WORKDIR /src
COPY ["NotifiTime-API.csproj", "./"]
RUN dotnet restore "NotifiTime-API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "NotifiTime-API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "NotifiTime-API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotifiTime-API.dll"]
