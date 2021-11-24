FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Student.IdentityServer/Student.IdentityServer.csproj", "Student.IdentityServer/"]
COPY ["Student.IdentityServer.Pgsql/Student.IdentityServer.Pgsql.csproj", "Student.IdentityServer.Pgsql/"]
RUN dotnet restore "Student.IdentityServer/Student.IdentityServer.csproj"
COPY . .
WORKDIR "/src/Student.IdentityServer"
RUN dotnet build "Student.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Student.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
ARG ASP_CONFIGURATION=Development
ENV ASPNETCORE_ENVIRONMENT=ASP_CONFIGURATION
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Student.IdentityServer.dll"]
