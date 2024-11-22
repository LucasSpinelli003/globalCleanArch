# Usando a imagem base do SDK .NET para compilar o código
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Definindo o diretório de trabalho
WORKDIR /app

# Copiando o arquivo de solução e os arquivos de projeto
COPY *.sln ./
COPY ./GLOBAL.API/*.csproj ./GLOBAL.API/
COPY ./GLOBAL.Application/*.csproj ./GLOBAL.Application/
COPY ./GLOBAL.Data/*.csproj ./GLOBAL.Data/
COPY ./GLOBAL.Domain/*.csproj ./GLOBAL.Domain/
COPY ./GLOBAL.IoC/*.csproj ./GLOBAL.IoC/
COPY ./GLOBAL.Tests/*.csproj ./GLOBAL.Tests/


# Copiando todo o código da aplicação
COPY . .

# Construindo o projeto
RUN dotnet build ./GLOBAL.API/GLOBAL.API.csproj -c Release -o /app/build

# Publicando o projeto da API
FROM build AS publish
RUN dotnet publish ./GLOBAL.API/GLOBAL.API.csproj -c Release -o /app/publish

# Usando a imagem base do ASP.NET Core para a imagem final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Copiando os arquivos publicados para o container
COPY --from=publish /app/publish .

# Definindo o comando de inicialização da API
ENTRYPOINT ["dotnet", "API.dll"]
