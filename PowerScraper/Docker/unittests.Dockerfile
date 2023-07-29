FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY ./PowerScraper/*.csproj ./PowerScraper/
COPY ./PowerScraper.UnitTests/*.csproj ./PowerScraper.UnitTests/

RUN dotnet restore PowerScraper/PowerScraper.csproj
RUN dotnet restore PowerScraper.UnitTests/PowerScraper.UnitTests.csproj

COPY ./PowerScraper ./PowerScraper/
COPY ./PowerScraper.UnitTests/ ./PowerScraper.UnitTests/

WORKDIR /app/PowerScraper.UnitTests

ENTRYPOINT ["dotnet", "test"]