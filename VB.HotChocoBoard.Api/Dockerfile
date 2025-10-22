FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["VB.BookStore.Api/VB.BookStore.Api.csproj", "VB.BookStore.Api/"]
RUN dotnet restore "VB.BookStore.Api/VB.BookStore.Api.csproj"
COPY . .
WORKDIR "/src/VB.BookStore.Api"
RUN dotnet build "./VB.BookStore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./VB.BookStore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VB.BookStore.Api.dll"]
