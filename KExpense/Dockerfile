#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["KExpense/KExpense.csproj", "KExpense/"]
COPY ["KExpense.Model/KExpense.Model.csproj", "KExpense.Model/"]
COPY ["KExpense.Service/KExpense.Service.csproj", "KExpense.Service/"]
COPY ["kContainer/kContainer.csproj", "kContainer/"]
COPY ["KExpense.Repository/KExpense.Repository.csproj", "KExpense.Repository/"]
RUN dotnet restore "KExpense/KExpense.csproj"
COPY . .
WORKDIR "/src/KExpense"
RUN dotnet build "KExpense.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KExpense.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KExpense.dll"]