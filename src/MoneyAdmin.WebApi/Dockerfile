FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MoneyAdmin.WebApi/MoneyAdmin.WebApi.csproj", "MoneyAdmin.WebApi/"]
RUN dotnet restore "MoneyAdmin.WebApi/MoneyAdmin.WebApi.csproj"
COPY . .
WORKDIR "/src/MoneyAdmin.WebApi"
RUN dotnet build "MoneyAdmin.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MoneyAdmin.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MoneyAdmin.WebApi.dll"]