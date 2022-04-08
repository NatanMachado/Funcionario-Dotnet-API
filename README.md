# Funcionario-Dotnet-API

O Projeto consiste em uma Web API capaz de cadastrar funcionários e a partir desse cadastro gerar o contracheque detalhando os lancamentos de remuneração e desconto com base no salário do mesmo.

O projeto utiliza _.Net Core 6.0_, _Docker_ e banco de dados _PostgreSQL_. 

- **GET: `api/Funcionario/{id}`**
  - Retorna um `json` com os dados do funcionário cadastrado com o respectivo `{id}`.
- **GET: `api/Funcionario`**
  - Retorna um `json` com os dados de todos os funcionários cadastrados.
- **GET: `api/Funcionario/{Id}/Contracheque`**
  - Retorna um `json` do contracheque do funcionário cadastrado com o respectivo `{id}`.
```json
{
    "mesReferencia": "April",
    "salarioBruto": 10000.00,
    "lancamentos": [
        {
            "tipo": "Remuneracao",
            "descricao": "Salário",
            "valor": 10000.00
        },
        {
            "tipo": "Desconto",
            "descricao": "FGTS",
            "valor": 800.00
        },
        {
            "tipo": "Desconto",
            "descricao": "INSS",
            "valor": 0.00
        },
        {
            "tipo": "Desconto",
            "descricao": "IRPF",
            "valor": 869.36
        },
        {
            "tipo": "Desconto",
            "descricao": "Plano Saude",
            "valor": 10.00
        },
        {
            "tipo": "Desconto",
            "descricao": "Plano Dental",
            "valor": 5.00
        }
    ],
    "totalDescontos": -1684.36,
    "salarioLiquido": 8315.64
}
```
- **POST: `api/Funcionario`**
  - Cadastra um funcionário passando o `json` com os dados do mesmo. O _endpoint_ retorna o id gerado para o respectivo funcionário se o cadastro foi realizado com sucesso.
  - Exemplo (dados fictícios):
```json
{
    "id": 0,
    "nome": "XXXXXXXXX",
    "sobrenome": "YYYYYYYYYYYYY",
    "documento": "139.015.240-53",
    "setor": "AAAAAAAAAAA",
    "salarioBruto": 1000.00,
    "admissao": "2022-04-02T23:09:32.313Z",
    "planoSaude": true,
    "planoDental": true,
    "valeTransporte": false
}
```

### Iniciar Aplicação (.NET 6.0.3)

- Certifique-se de que o [.NET 6.0.3](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) esteja instalado.
- Faça o [clone do projeto](https://github.com/NatanMachado/Funcionario-Dotnet-API.git) 
- Na pasta raiz do projeto execute por um terminal:
  - Aplicação: `dotnet run --project Funcionario-API`
  - Testes: `dotnet test`

### Iniciar Aplicação (Docker)

- Certifique de que tenha o [Docker](https://docs.docker.com/get-docker/) instalado.
- Execute o comando por um terminal:
  - `docker run -d -p {porta disponível}:80 codeuai/employee-api`