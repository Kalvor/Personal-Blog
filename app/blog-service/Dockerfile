FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 4000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/blog-service.RestApi/blog-service.RestApi.csproj", "src/blog-service.RestApi/"]
RUN dotnet restore "./src/blog-service.RestApi/./blog-service.RestApi.csproj"
COPY . .
WORKDIR "/src/src/blog-service.RestApi"
RUN dotnet build "./blog-service.RestApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./blog-service.RestApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "blog-service.RestApi.dll"]