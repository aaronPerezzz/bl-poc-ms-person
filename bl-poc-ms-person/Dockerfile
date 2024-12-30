#Get .Net Core image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/bl-poc-ms-person
COPY ["./bl-poc-ms-person.csproj", "bl-poc-ms-person/"] 
RUN dotnet restore "./bl-poc-ms-person.csproj"
COPY . .

RUN dotnet build "./bl-poc-ms-person.csproj" -c $BUILD_CONFIGURATION -o /app/build
#Copying the rest of the files and build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./bl-poc-ms-person.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


ENTRYPOINT ["dotnet", "bl-poc-ms-person.dll"]