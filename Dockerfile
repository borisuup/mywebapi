FROM microsoft/dotnet:1.0-runtime
WORKDIR /app
COPY ./release /app
ENV ASPNETCORE_URLS http://*:8001
EXPOSE 8001
ENTRYPOINT dotnet MyWebApi.dll