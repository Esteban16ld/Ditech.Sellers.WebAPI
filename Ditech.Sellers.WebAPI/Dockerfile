FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR Sellers.App

EXPOSE 5000
EXPOSE 5001

#project files
COPY ./*.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

#Build
FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /Sellers.Api
COPY --from=build /Sellers.App/out .
ENTRYPOINT ["dotnet", "Ditech.Sellers.WebAPI.dll"]