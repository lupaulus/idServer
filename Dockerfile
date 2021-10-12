FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Student.IdentityServer/Student.IdentityServer.csproj", "Student.IdentityServer/"]
RUN dotnet restore "Student.IdentityServer/Student.IdentityServer.csproj"
COPY . .
WORKDIR "/src/Student.IdentityServer"
RUN dotnet build "Student.IdentityServer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Student.IdentityServer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Student.IdentityServer.dll"] 