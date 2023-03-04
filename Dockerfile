#Building stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./wtalk.Api/Wtalk.Api.csproj" --disable-parallel
RUN dotnet publish "./wtalk.Api/Wtalk.Api.csproj" -c release -o /app --no-restore

#Serve stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

ENV ASPNETCORE_URLS=http://+:8000
EXPOSE 8000

ENTRYPOINT ["dotnet", "Wtalk.Api.dll"]