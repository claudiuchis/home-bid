FROM microsoft/dotnet:2.2-sdk
WORKDIR /app

COPY HomeBid.sln ./
COPY src ./src
COPY test ./test

# restore all projects
RUN dotnet restore HomeBid.sln
