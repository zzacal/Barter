#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Barter.Web/Barter.Web.csproj", "Barter.Web/"]
RUN dotnet restore "Barter.Web/Barter.Web.csproj"
COPY . .
WORKDIR "/src/Barter.Web"
RUN dotnet build "Barter.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Barter.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Barter.Web.dll"]