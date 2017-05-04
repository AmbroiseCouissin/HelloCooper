FROM microsoft/dotnet:1.1.1-sdk
LABEL name "hello-cooper"

WORKDIR /app
COPY . /app

ENV ASPNETCORE_URLS http://*:8080
EXPOSE 8080/tcp

ENTRYPOINT ["dotnet", "HelloCooper.dll"]
