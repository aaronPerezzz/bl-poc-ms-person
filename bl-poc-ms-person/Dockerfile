#Get .Net Core image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

#Copying csproj and restore
COPY *.csproj ./
RUN dotnet restore

#Copying the rest of the files and build
COPY . ./
RUN dotnet publish -c Release -o out

#Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80/tcp

ENTRYPOINT ["dotnet", "bl-poc-ms-person.dll"]