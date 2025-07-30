# ---------- build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy csproj and restore
COPY ["Bright Future.csproj", "./"]
RUN dotnet restore "Bright Future.csproj"

# copy the rest and publish
COPY . .
RUN dotnet publish "Bright Future.csproj" -c Release -o /app/publish \
    /p:UseAppHost=false

# ---------- runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# tell ASP.NET Core to listen on whatever port Render assigns
ENV ASPNETCORE_URLS=http://+:${PORT}

# OPTIONAL: not strictly required, but documents the port
EXPOSE 10000

# avoid the space in the file name if you can
ENTRYPOINT ["dotnet", "BrightFuture.dll"]