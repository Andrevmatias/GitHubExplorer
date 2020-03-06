# GitHubExplorer

Aplicativo Web para busca de repositórios no GitHub

## Tecnologias e Bibliotecas Utilizadas

###Back-end

**[ASP.NET Core 3.1](https://dotnet.microsoft.com/):** Framework multi-plataforma para desenvolvimento de aplicativos web. A linguagem usada foi C#. 

**[NuGet](https://www.nuget.org/):** Gerenciador de pacotes para .NET.

**[xUnit](https://xunit.net/):** Conjunto de ferramentas para teste unitário em .NET.

**[Octokit.NET](https://github.com/octokit/octokit.net):** Biblioteca para .NET de cliente para a API do GitHub.

### Front-end

**[Angular 9](https://angular.io/):** Framework JS para desenvolvimento de front-end SPA. A linguagem usada foi TypesScript 3.7.

**[NPM](https://www.npmjs.com/):** Gerenciador de pacotes JavaScript.

**[Bootstrap 4(CSS)](https://getbootstrap.com/):** Biblioteca CSS para desenvolvimento de aplicativos Web responsivos. 

**[Font Awesome](https://fontawesome.com/):** Pacote de ícones para Web.

##Para Executar Localmente:

1. Instale o ASP.NET Core SDK 3.1: <https://dotnet.microsoft.com/download/dotnet-core/3.1>
2. Instale o Node.js e o NPM: <https://nodejs.org/>
3. No terminal, navegue até a pasta "GitHubExplorer.App" e execute
```
dotnet run
```

Deve ser exibido o endereço e a porta onde o programa está sendo executado.

###Para executar os testes:
Navegue até a pasta "GitHubExplorer.Tests" e execute
```
dotnet test
```

### Usando Docker:
1. Instale o Docker <https://www.docker.com/>
2. No terminal, navegue até a pasta "GitHubExplorer.App" e execute
```
docker build -t andrevm-github-explorer .
```
para gerar a imagem.
3. Execute 
```
docker run -p 127.0.0.1:8080:80/tcp andrevm-github-explorer
```

O aplicativo deve estar rodando na porta 8080.