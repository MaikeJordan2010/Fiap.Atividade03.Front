# Here, we include the dotnet core SDK as the base to build our app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8081
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Atividade03.Front.csproj","."]

RUN dotnet restore "Atividade03.Front.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "Atividade03.Front.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Atividade03.Front.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT [ "dotnet", "./Atividade03.Front.dll" ]

# We then get the base image for Nginx and set the 
# work directory 
FROM nginx:alpine
WORKDIR /usr/share/nginx/html

# # We'll copy all the contents from wwwroot in the publish
# # folder into nginx/html for nginx to serve. The destination
# # should be the same as what you set in the nginx.conf.
COPY --from=publish /app/publish/wwwroot /usr/local/webapp/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf
EXPOSE 8080