FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CathaybkExam/CathaybkExam.csproj", "CathaybkExam/"]
RUN dotnet restore "CathaybkExam/CathaybkExam.csproj"
COPY . .
WORKDIR "/src/CathaybkExam"
RUN dotnet build "CathaybkExam.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CathaybkExam.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CathaybkExam.dll"]
