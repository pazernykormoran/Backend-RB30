FROM mcr.microsoft.com/dotnet/aspnet:3.1-focal AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build
WORKDIR /src
COPY ["RetireBefore30.csproj", "./"]
RUN dotnet restore "RetireBefore30.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "RetireBefore30.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RetireBefore30.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RetireBefore30.dll"]
