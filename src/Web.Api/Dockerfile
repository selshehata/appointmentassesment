#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Web.Api/Web.Api.csproj", "src/Web.Api/"]
COPY ["src/Core.Application/Core.Application.csproj", "src/Core.Application/"]
COPY ["src/Core.Domain/Core.Domain.csproj", "src/Core.Domain/"]
COPY ["src/Infrastructure.Identity/Infrastructure.Identity.csproj", "src/Infrastructure.Identity/"]
COPY ["src/Infrastructure.Persistence/Infrastructure.Persistence.csproj", "src/Infrastructure.Persistence/"]
COPY ["src/Infrastructure.Shared/Infrastructure.Shared.csproj", "src/Infrastructure.Shared/"]
RUN dotnet restore "./src/Web.Api/./Web.Api.csproj"
COPY . .
WORKDIR "/src/src/Web.Api"
RUN dotnet build "./Web.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Web.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.Api.dll"]