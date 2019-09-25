FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

COPY HomeBid.sln ./
COPY src ./src
COPY tests ./tests

# restore all projects
RUN dotnet restore HomeBid.sln

# run unit tests
RUN dotnet test ./src/Services/Bidding/Bidding.UnitTests \
    --results-directory /results \
    --logger "trx;LogFileName=results.xml"

# build and publish
RUN dotnet publish src/Services/Bidding/Bidding.Service/Bidding.Service.csproj \
     -c Release -o out

# build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
EXPOSE 80
COPY --from=build /app/src/Services/Bidding/Bidding.Service/out .

ENTRYPOINT ["dotnet", "Bidding.Service.dll"]