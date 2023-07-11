FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MachineLearning.Web/MachineLearning.Web.csproj", "MachineLearning.Web/"]
RUN dotnet restore "MachineLearning.Web/MachineLearning.Web.csproj"
COPY . .
WORKDIR "/src/MachineLearning.Web"
RUN dotnet build "MachineLearning.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MachineLearning.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MachineLearning.Web.dll"]
