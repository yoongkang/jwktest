FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
RUN mkdir /code
WORKDIR /code
