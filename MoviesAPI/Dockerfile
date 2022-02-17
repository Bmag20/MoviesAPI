FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY ["MoviesAPI.csproj", "./"]
RUN dotnet restore "MoviesAPI.csproj"
COPY . .

RUN dotnet publish "MoviesAPI.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS final
WORKDIR /app
EXPOSE 5001
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MoviesAPI.dll"]
