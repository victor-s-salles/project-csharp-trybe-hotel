# 🏨 Projeto Trybe Hotel
Este projeto consiste em uma API back-end desenvolvida em C# com o propósito de estabelecer um sistema de gestão para um empreendimento hoteleiro. A API oferece funcionalidades para autenticação e registro de usuários, administração de cidades, hotéis, quartos e reservas, bem como inclui um serviço externo para calcular os hotéis registrados mais próximos. Conta com um mecanismo de autenticação, onde há endpoints que demandam que o usuário possua o token adquirido no momento do login, e esse token deve ser fornecido na requisição. Alguns desses endpoints requerem permissões específicas, como Administrador e Cliente.
<br>

## 📝 Aprendizados com este projeto
- C#
- ASP.NET
- Entity Framework
- Docker
- JWT (Json Web Token)
- Azure Data Studio

<details>
  <summary><strong>‼️ Antes de começar a desenvolver</strong></summary><br />

  1. Clone o repositório

  2. Instale as dependências
  
  - Entre na pasta `src/`.
  - Execute o comando: `dotnet restore`.
  
  3. Crie uma branch a partir da branch `master`

  4. Adicione as mudanças ao _stage_ do Git e faça um `commit`

  5. Adicione a sua branch com o novo `commit` ao repositório remoto

  6. Crie um novo `Pull Request` _(PR)_

</details>

<details>
  <summary><strong>🎛 Linter</strong></summary><br />

  Usaremos o [NetAnalyzer](https://docs.microsoft.com/pt-br/dotnet/fundamentals/code-analysis/overview) para fazer a análise estática do seu código.

  Este projeto já vem com as dependências relacionadas ao _linter_ configuradas no arquivo `.csproj`.

  O analisador já é instalado pelo plugin da `Microsoft C#` no `VSCode`. Para isso, basta fazer o download do [plugin](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) e instalá-lo.
</details>

<details>
  <summary><strong>🛠 Testes</strong></summary><br />

  O .NET já possui sua própria plataforma de testes.
  
  Este projeto já vem configurado e com suas dependências.

  ### Executando todos os testes

  Para executar os testes com o .NET, execute o comando dentro do diretório do seu projeto `src`!

  ```
  dotnet test
  ```

  ### Executando um teste específico

  Para executar um teste específico, basta executar o comando `dotnet test --filter Name~TestMethod1`.

  :warning: **Importante:** o comando irá executar testes cujo nome contém `TestMethod1`.

  :warning: **O avaliador automático não necessariamente avalia seu projeto na ordem em que os requisitos aparecem no readme. Isso acontece para deixar o processo de avaliação mais rápido. Então, não se assuste se isso acontecer, ok?**

  ### Outras opções para testes
  - Algumas opções que podem lhe ajudar são:
    -  `-?|-h|--help`: exibe a descrição completa de como utilizar o comando.
    -  `-t|--list-tests`: lista todos os testes, ao invés de executá-los.
    -  `-v|--verbosity <LEVEL>`: define o nível de detalhe na resposta dos testes.
      - `q | quiet`
      - `m | minimal`
      - `n | normal`
      - `d | detailed`
      - `diag | diagnostic`
      - Exemplo de uso: 
         ```
           dotnet test -v diag
         ```
         ou
         ```            
           dotnet test --verbosity=diagnostic
         ``` 
</details>

## Requisitos do projeto

Você está iniciando o desenvolvimento de uma API que será utilizada em uma aplicação de booking de várias redes de hotéis.

Para iniciar o desenvolvimento, você desenvolverá algumas rotas das entidades acerca das cidades, hotéis e quartos que servirão para, no futuro, realizar o booking de pessoas clientes.

No intuito de auxiliar o desenvolvimento, o time de produto já disponibilizou o diagrama de entidade-relacionamento e o time de DevOps disponibilizou um container na qual você poderá utilizar um banco de dados.

O sistema está dividido em diretórios específicos para auxiliar na organização e desenvolvimento do projeto.

- `Controllers/`: Este diretório armazena os arquivos com as lógicas dos controllers da aplicação. Os métodos a serem desenvolvidos estão prontos mas sem implementação alguma, o que você desenvolverá ao longo do projeto.
<br />

- `Models/`: Este diretório armazena os arquivos com as models do banco de dados. As models `City`, `Hotel` e `Room` serão as instruções para as tabelas `Cities`, `Hotels` e `Rooms`. Lembre-se, o nome da tabela não é dado pelo nome da model mas sim pelo nome do `DBSet<model>` presente no contexto.
<br />

- `DTO/`: Este diretório armazena as classes de DTO. Algumas rotas esperam as `responses` baseadas nestes DTOs. Você pode conferir isso pelo requisito do projeto e pelo retorno dos métodos dos `repositories`.
<br />

- `Repository/`: Este diretório armazena as lógicas que farão a interação com o banco de dados. Os métodos de cada requisito já estão criados e você deverá incluir a implementação de cada um desses métodos respeitando o retorno do DTO. Além disso, você terá o arquivo `TrybeHotelContext` com o contexto para a conexão com o banco de dados. Todos os `repository` e o `context` possuem interfaces que estão nesse diretório e fornecem o contrato para essas classes.
<br />

<details id='der'>
  <summary><strong>🎲 Banco de Dados</strong></summary>
  <br/>

  Para o desenvolvimento, o time de produto disponibilizou um *Diagrama de Entidade-Relacionamento (DER)* para construir a modelagem do banco de dados. Com essa imagem você já consegue saber:
  - Como nomear suas tabelas e colunas;
  - Quais são os tipos de suas colunas;
  - Relações entre tabelas.

    ![banco de dados](img/der.png)

  O diagrama infere 03 tabelas:
  - ***Cities***: tabela que armazenará um conjunto de cidades nas quais os hotéis estão localizados.
  - ***Hotels***: tabela que armazenará os hotéis da nossa aplicação. Note que informamos o `CityId`, atributo que armazenará o id da cidade.
  - ***Rooms***: tabela que armazenará os quartos de cada hotel da nossa aplicação. Note que informamos o `HotelId`, atributo que armazenará o id do hotel.

  Acerca dos relacionamentos, pelo diagrama de entidade-relacionamento temos:
  - Uma cidade pode ter vários hotéis.
  - Um hotel pode ter vários quartos.

  ⚠️ **Você poderá criar migrations para visualizar o banco de dados**

</details>

<details>
<summary><strong>🐳 Docker</strong></summary><br />

Para auxiliar no desenvolvimento, este projeto possui um arquivo do docker compose para subir um serviço do banco de dados `Azure Data Studio`. Este banco de dados possui a mesma arquitetura do `SQL Server`.

Para subir o serviço, utilize o comando:

```shell
docker-compose up -d --build
```

Para conectar ao seu sistema de gerenciamento de banco de dados, utilize as seguintes credenciais:

- `Server`: localhost
- `User`: sa
- `Password`: TrybeHotel12!
- `Database`: TrybeHotel
- `Trust server certificate`: true

Para criar o contexto do banco de dados na sua aplicação, utilize como connection string:

```csharp
var connectionString = "Server=localhost;Database=TrybeHotel;User=SA;Password=TrybeHotel12!;TrustServerCertificate=True";
```

⚠️ ** Essa connection string poderá ser utilizada no requisito 1 **

</details>



# 👩‍💻 Endpoints

### Login

O metodo é responsável por autenticar os usuários e retornar um token de autenticação que será usado nas seguintes requisições. <br>
Possui o metodo: POST. 

<details>
<summary> POST /login </summary>

O corpo da requisição deve serguir o exemplo:

    {
        "email": "exemplo@email.com",
        "password": "senha123"
    }

Retorna um token JWT de autenticação caso login ocorra com sucesso:

    {
        "token": "..."
    }

</details>

<hr>

### User
É responsável por criar um novo usuário no banco de dados, também é possivel consultar os usuários já cadastrados, caso a pessoa tenha a permissão de administrador e esteja autenticado. <br>
Possui os metodos: GET e POST. 

<details>

<summary> GET /user </summary>
Não é necessario informar nada no corpo da requisição, mas é necessario um token de autenticação e permissões de administrador.

Retorna uma lista dos usuarios cadastrados:

    [
        {
            "userId": 1,
            "name": "Admin",
            "email": "admin@trybehotel.com",
            "userType": "admin"
        },
        {
            "userId": 2,
            "name": "Cliente",
            "email": "cliente@trybehotel.com",
            "userType": "client"
        },
        [...]
    ]

</details>

<details>
<summary> POST /user </summary>

O corpo da requisição deve serguir o exemplo:

    {
        "name": "Cliente",
        "email": "cliente@trybehotel.com",
        "password": "senha123"
    }


Retorna os dados do novo usuario cadastrado:

    {
        "userId": 2,
        "name": "Cliente",
        "email": "cliente@trybehotel.com",
        "userType": "client"
    }

</details>

<hr>

### City
É responsável por criar e editar uma cidade no banco de dados, também é possível consultar as cidades já cadastradas. <br>
Possui os metodos: GET, POST e PUT. 

<details>
<summary> GET /city </summary>

Não é necessario informar nada no corpo da requisição.

Retorna todas as cidades cadastradas no banco de dados:

    [
        {
            "cityId": "1",
            "name": "São Paulo",
            "state": "SP"
        },
        [...]
    ]

</details>

<details>
<summary> POST /city </summary>

O corpo da requisição deve serguir o exemplo:

    {
        "name": "São Paulo",
        "state": "SP"
    }

Retorna todas as cidades cadastradas no banco de dados:

    [
        {
            "cityId": "1",
            "name": "São Paulo",
            "state": "SP"
        },
        [...]
    ]

</details>

<details>
<summary> PUT /city </summary>

O corpo da requisição deve serguir o exemplo:

    {
        "cityId": 1,
        "name": "São Paulo",
        "state": "SP"
    }

Retorna a cidade atualizada no banco de dados:

    {
        "cityId": "1",
        "name": "São Paulo",
        "state": "SP"
    }

</details>

<hr>

### Hotel
É responsável por consultar todos os hotéis cadastrados, e também por criar novos hotéis caso a pessoa tenha a permissão necessária.<br>
Possui os metodos: GET e POST. 

<details>
<summary> GET /hotel </summary>

Não é necessario informar nada no corpo da requisição.

Retorna todas os hoteis cadastrados no banco de dados:

    [
        {
            "hotelId": 1,
            "name": "Trybe Hotel",
            "address": "Avenida Paulista",
            "cityId": "1",
            "cityName": "São Paulo",
            "state": "SP"
        },
        [...]
    ]

</details>

<details>
<summary> POST /hotel </summary>

O corpo da requisição deve serguir o exemplo:

    {
        "name": "Trybe Hotel",
        "address": "Avenida Paulista",
        "cityId": 1
    }

Retorna todas os hoteis cadastrados no banco de dados:

    [
        {
            "hotelId": 1,
            "name": "Trybe Hotel",
            "address": "Avenida Paulista",
            "cityId": "1",
            "cityName": "São Paulo",
            "state": "SP"
        },
        [...]
    ]

</details>

<hr>

### Room
É responsável por criar um novo quarto relacionado a algum hotel, também é possível consultar os detalhes de um quarto específico, e remover quartos existentes.<br>
Possui os metodos: GET, POST e DELETE. 

<details>
<summary> GET /room/:hotelId </summary>

Não é necessario informar nada no corpo da requisição, mas é necessario informar um `hotelId` no endereço.

Retorna todos os quartos de um específico hotel:

    [
        {
            "roomId": 1,
		    "name": "Suite básica",
		    "capacity": 2,
		    "image": "image suite",
		    "hotel": {
                "hotelId": 1,
                "name": "Trybe Hotel",
                "address": "Avenida Paulista",
                "cityId": "1",
                "cityName": "São Paulo",
                "state": "SP"
            }
        },
        [...]
    ]

</details>

<details>
<summary> POST /room </summary>

O corpo da requisição deve serguir o exemplo:

    {
        "name":"Suite básica",
        "capacity":2,
        "image":"image suite",
        "hotelId": 1
    }

Retorna todos os quartos de um específico hotel:

    [
        {
            "roomId": 1,
		    "name": "Suite básica",
		    "capacity": 2,
		    "image": "image suite",
		    "hotel": {
                "hotelId": 1,
                "name": "Trybe Hotel",
                "address": "Avenida Paulista",
                "cityId": "1",
                "cityName": "São Paulo",
                "state": "SP"
            }
        },
        [...]
    ]

</details>

<details>
<summary> DELETE /room/:roomId </summary>

Não é necessario informar nada no corpo da requisição, mas é necessario informar um `roomId` no endereço.

Retorna apenas um status de sucesso caso o quarto seja deletado.

</details>

<hr>

### Booking
É responsável por criar uma reserva de algum quarto existente, também é possível consultar a reserva, caso seja você que a tenha criado.<br>
Possui os metodos: GET e POST. 

<details>
<summary> GET /booking/:bookingId </summary>

Não é necessario informar nada no corpo da requisição, mas é necessario informar um `bookingId` no endereço, também é requerido um token de autenticação. A resposta só retorna os detalhes da reserva, caso você seja o resposavel por ela.

Retorna os detalhes da reserva:

    [
        {
            "bookingId": 1,
            "checkIn": "2030-08-27T00:00:00",
            "checkOut": "2030-08-28T00:00:00",
            "guestQuant": 1,
            "room": {
                "roomId": 1,
                "name": "Suite básica",
                "capacity": 2,
                "image": "image suite",
                "hotel": {
                    "hotelId": 1,
                    "name": "Trybe Hotel",
                    "address": "Avenida Paulista",
                    "cityId": "1",
                    "cityName": "São Paulo",
                    "state": "SP"
                }
            }
        },
        [...]
    ]

</details>

<details>
<summary> POST /booking </summary>

O corpo da requisição deve serguir o exemplo, é necessario informar um token de autenticação:

    {
        "CheckIn":"2030-08-27",
        "CheckOut":"2030-08-28",
        "GuestQuant":"1",
        "RoomId":1
    }

Retorna os detalhes da reserva criada:

    [
        {
            "bookingId": 1,
            "checkIn": "2030-08-27T00:00:00",
            "checkOut": "2030-08-28T00:00:00",
            "guestQuant": 1,
            "room": {
                "roomId": 1,
                "name": "Suite básica",
                "capacity": 2,
                "image": "image suite",
                "hotel": {
                    "hotelId": 1,
                    "name": "Trybe Hotel",
                    "address": "Avenida Paulista",
                    "cityId": "1",
                    "cityName": "São Paulo",
                    "state": "SP"
                }
            }
        },
        [...]
    ]

</details>

<hr>
