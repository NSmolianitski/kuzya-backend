FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["KuzyaBackend.Web/KuzyaBackend.Web.csproj", "KuzyaBackend.Web/"]
COPY ["KuzyaBackend.DataAccess/KuzyaBackend.DataAccess.csproj", "KuzyaBackend.DataAccess/"]
COPY ["KuzyaBackend.DataAccess.Models/KuzyaBackend.DataAccess.Models.csproj", "KuzyaBackend.DataAccess.Models/"]
COPY ["KuzyaBackend.Services/KuzyaBackend.Services.csproj", "KuzyaBackend.Services/"]
COPY ["KuzyaBackend.Web.DTOs/KuzyaBackend.Web.DTOs.csproj", "KuzyaBackend.Web.DTOs/"]
RUN dotnet restore "KuzyaBackend.Web/KuzyaBackend.Web.csproj"
COPY . .
WORKDIR "/src/KuzyaBackend.Web"
RUN dotnet build "KuzyaBackend.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "KuzyaBackend.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KuzyaBackend.Web.dll"]
