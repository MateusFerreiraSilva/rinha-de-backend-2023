FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

ENV ASPNETCORE_ENVIRONMENT Production

WORKDIR /dotnet-app

# Copy everything
COPY . .

# Restore as distinct layers
RUN dotnet restore

# Build and publish a release
RUN dotnet publish -c Release -o out


WORKDIR /dotnet-app

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as run-env
COPY --from=build-env /dotnet-app/out /publish

WORKDIR /publish

EXPOSE 80

ENTRYPOINT ["dotnet", "rinha-de-backend-2023.dll"]
