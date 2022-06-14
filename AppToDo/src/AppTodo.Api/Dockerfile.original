#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

# VARIÁVEL DE AMBIENTE PARA PODERMOS RODAR NO BROSERW
ENV ASPNETCORE_URLS=http://+:8000;http://+:80;
ENV ASPNETCORE_ENVIRONMENT=Development


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/AppTodo.Api/AppTodo.Api.csproj", "src/AppTodo.Api/"]
COPY ["src/AppTodo.Application/AppTodo.Application.csproj", "src/AppTodo.Application/"]
COPY ["src/AppTodo.Core/AppTodo.Core.csproj", "src/AppTodo.Core/"]
COPY ["src/AppTodo.Infrastructure/AppTodo.Infrastructure.csproj", "src/AppTodo.Infrastructure/"]
RUN dotnet restore "src/AppTodo.Api/AppTodo.Api.csproj"
COPY . .
WORKDIR "/src/src/AppTodo.Api"
RUN dotnet build "AppTodo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppTodo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppTodo.Api.dll"]