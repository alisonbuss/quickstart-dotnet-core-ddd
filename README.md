
ADICIONAR DEPENDÊNCIA DO PROJETO:
ADD PROJECT DEPENDENCY:





ADICIONAR DEPENDÊNCIA DO PACOTE:
ADD PACKAGE DEPENDENCY:

APP
dotnet add package AutoMapper --version 10.0.0

INFRA CROSS
dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions --version 3.1.5
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 8.0.0

INFRA DATA
dotnet add package Microsoft.EntityFrameworkCore --version 3.1.5
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 3.1.5
dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 3.1.5
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 3.1.5
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 3.1.5

SERVICE API
dotnet add package Microsoft.EntityFrameworkCore --version 3.1.5
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 3.1.5
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 3.1.5
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 3.1.5



PUBLICAR PROJETO


dotnet tool install --global dotnet-ef

dotnet ef migrations add Initial --output-dir Migrations --context DbContextMigration --startup-project "./src/Infra/ExampleUsersDDD.Infra.Data" --verbose;

dotnet ef database update --context DbContextMigration --startup-project "./src/Infra/ExampleUsersDDD.Infra.Data" --verbose;



export ASPNETCORE_ENVIRONMENT=Development;
export ASPNETCORE_ENVIRONMENT=Production;

dotnet restore --force --verbosity n;

dotnet build --configuration Debug --output ./builds/API --verbosity n --force;

dotnet publish --configuration Debug --output ./builds/API/publish --verbosity n --force;


dotnet "./builds/API/publish/ExampleUsersDDD.Service.API.dll" --verbosity n --force;

Ou

dotnet run --project ./src/Services/ExampleUsersDDD.Service.API/ExampleUsersDDD.Service.API.csproj --verbosity n --force;


dotnet list package





https://medium.com/tableless/tratamento-global-de-exceptions-1ad613f58dbd

https://www.wellingtonjhn.com/posts/padroniza%C3%A7%C3%A3o-de-respostas-de-erro-em-apis-com-problem-details/





https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/?view=aspnetcore-3.1&tabs=linux

https://code-maze.com/aspnetcore-webapi-best-practices/


https://www.youtube.com/watch?v=but7jqjopKM

https://code-maze.com/global-error-handling-aspnetcore/


https://code-maze.com/aspnetcore-webapi-best-practices/

https://medium.com/@jelleverheyen/automatically-handle-exceptions-in-dotnet-core-api-2090d2e574dd










http://blog.travisgosselin.com/configured-user-limit-inotify-instances/



```text

projects
    # Criar uma Solution
    Authorization
        ...

    # Criar uma Solution
    Authentication                               # dotnet new sln
        1 - Services
            * Authentication.API                 # dotnet new webapi Authentication.API
        2 - Business
            * Authentication.Business            # dotnet new classlib Authentication.Business
                Dtos/
                Abstracts/
        3 - Domain
            * Authentication.Domain              # dotnet new classlib Authentication.Domain
                Abstracts/
                  Datagrid/
                  Repository/
                  Service/
                Entities/
                Service/
                Enums/
        4 - Infra
            * Authentication.InfraData           # dotnet new classlib Authentication.InfraData
                Concrete/
                
            * Authentication.InfraCrossCutting   # dotnet new classlib Authentication.InfraCrossCutting
                .../


JWT .Net Core e REST
https://www.brunobrito.net.br/jwt-com-chave-assimetrica/
https://www.brunobrito.net.br/jwt-assinaura-digital-rsa-ecdsa-hmac/
https://www.brunobrito.net.br/jose-jwt-jws-jwe-jwa-jwk-jwks/

https://www.brunobrito.net.br/padrao-rest/
https://www.brunobrito.net.br/aspnet-core-api-restful/
https://www.brunobrito.net.br/api-restful-boas-praticas/

https://imasters.com.br/back-end/mediator-pattern-com-mediatr-asp-net-core-2-2

https://dotnetdetail.net/cqrs-and-mediator-patterns-in-asp-net-core-3-1/


https://medium.com/old-dev/basic-entityframework-core-192dfdff37f8



TIPO DO BANCO
STRING DE CONEC

https://medium.com/old-dev/basic-entityframework-core-192dfdff37f8


https://www.wellingtonjhn.com/posts/padroniza%C3%A7%C3%A3o-de-respostas-de-erro-em-apis-com-problem-details/

https://codingsight.com/configuation-comparison-dependency-injection-containers/

https://www.meziantou.net/entity-framework-core-specifying-data-type-length-and-precision.htm 

Ju212146357br
PY488482898BR


dotnet restore ExampleUsersDDD.sln 


The missing GUI Client for GRPC services
https://github.com/uw-labs/bloomrpc


https://medium.com/danielpadua/vscode-asp-net-core-preparar-ambiente-de-desenvolvimento-adf30cefea07

https://medium.com/@renato.groffe/net-core-visual-studio-code-criando-rapidamente-classes-e-interfaces-com-c-extensions-e73bad83e867

https://dev.to/hatsrumandcode/net-core-2-why-xunit-and-not-nunit-or-mstest--aei


https://www.wellingtonjhn.com/posts/configurando-suas-aplica%C3%A7%C3%B5es-.net-core/

https://www.brunobrito.net.br/asp-net-core-ioc-estrategia/

https://blog.geekhunter.com.br/utilizando-a-biblioteca-mediatr-com-asp-net-core/

https://github.com/lamondlu/Library

https://www.brunobrito.net.br/asp-net-core-ioc-estrategia/

DDD é um conjunto de praticas de implementação, que tem o objetivo de facilitar a implementação complexo de regras e processos de negocios.



https://blog.bitsrc.io/how-to-pass-environment-info-during-docker-builds-1f7c5566dd0e


https://www.baeldung.com/ops/docker-container-environment-variables

https://vsupalov.com/docker-arg-env-variable-guide/

```


### Extensões/plugins do Visual Studio Code utilizado neste projeto.

#### C# (powered by OmniSharp), [link](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).

Instalação via terminal:

```shell
$ code --install-extension ms-dotnettools.csharp
```

#### C# Extensions (powered by jchannon), [link](https://marketplace.visualstudio.com/items?itemName=jchannon.csharpextensions).

Instalação via terminal:

```shell
$ code --install-extension jchannon.csharpextensions
```

#### vscode-solution-explorer (powered by Fernando Escolar), [link](https://marketplace.visualstudio.com/items?itemName=fernandoescolar.vscode-solution-explorer).

Instalação via terminal:

```shell
$ code --install-extension fernandoescolar.vscode-solution-explorer
```



code --install-extension aurentTreguier.vscode-simple-icons
