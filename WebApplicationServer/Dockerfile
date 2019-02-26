FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["WebApplicationServer/WebApplicationServer.csproj", "WebApplicationServer/"]
RUN dotnet restore "WebApplicationServer/WebApplicationServer.csproj"
COPY . .
WORKDIR "/src/WebApplicationServer"
RUN dotnet build "WebApplicationServer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebApplicationServer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApplicationServer.dll"]