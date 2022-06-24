#Building stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./Wtalk.Api/Wtalk.Api.csproj" --disable-parallel
RUN dotnet publish "./Wtalk.Api/Wtalk.Api.csproj" -c release -o /app --no-restore

#Serve stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "Wtalk.Api.dll"]