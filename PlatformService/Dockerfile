FROM mcr.microsoft.com/dotnet/sdk:8.0 AS buildenv
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore "PlatformService.csproj"

COPY . ./
RUN dotnet publish "PlatformService.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=buildenv app/out .
ENTRYPOINT [ "dotnet", "PlatformService.dll" ]