FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
RUN mkdir src test
COPY ./manipulae/*.csproj /app/src/.
COPY ./manipulae-unit-test/*.csproj /app/test/.
RUN dotnet restore /app/src/manipulae.csproj
RUN dotnet restore /app/test/manipulae-unit-test.csproj
COPY . .
RUN dotnet build
RUN dotnet test

RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as publish
WORKDIR /publish
COPY --from=build /publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "manipulae.dll"]