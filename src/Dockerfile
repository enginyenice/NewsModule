FROM mcr.microsoft.com/dotnet/aspnet:6.0 as base
FROM mcr.microsoft.com/dotnet/sdk:6.0 as sdk

WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY ./NewsModule.API/*.csproj src/NewsModule.API/
COPY ./NewsModule.Business/*.csproj src/NewsModule.Business/
COPY ./NewsModule.DataAccess/*.csproj src/NewsModule.DataAccess/
COPY ./NewsModule.DTOs/*.csproj src/NewsModule.DTOs/
COPY ./NewsModule.Entities/*.csproj src/NewsModule.Entities/

RUN dotnet restore src/NewsModule.API/*.csproj

COPY ./NewsModule.API src/NewsModule.API
COPY ./NewsModule.Business src/NewsModule.Business
COPY ./NewsModule.DataAccess src/NewsModule.DataAccess
COPY ./NewsModule.DTOs src/NewsModule.DTOs
COPY ./NewsModule.Entities src/NewsModule.Entities

WORKDIR /app/src/NewsModule.API
RUN dotnet build "NewsModule.API.csproj" -c Release -o /app/build

FROM sdk AS publish
RUN dotnet publish "NewsModule.API.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "NewsModule.API.dll" ]



