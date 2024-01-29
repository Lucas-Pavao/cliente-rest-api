
```
# Minha API

Este é um projeto de API construído usando .NET Core, PostgreSQL e Entity Framework Core.

## Pré-requisitos

Antes de começar, certifique-se de ter os seguintes itens instalados em seu sistema:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)

## Configuração do Banco de Dados

1. **Crie um Banco de Dados PostgreSQL:**
   - Instale o PostgreSQL em seu sistema.
   - Abra o PostgreSQL e crie um novo banco de dados. Anote o nome do banco de dados, o usuário e a senha.

2. **Adicione as Configurações do Banco de Dados à API:**
   - Abra o arquivo `appsettings.json` no diretório da API.
   - Substitua `<sua_string_de_conexao>` pelas informações do seu banco de dados PostgreSQL.
     ```json
     {
       "ConnectionStrings": {
         "Default": "Host=localhost;Port=5432;Database=seu_banco_de_dados;Username=seu_usuario;Password=sua_senha;"
       },
       // ... outras configurações ...
     }
     ```

## Rodando a API

1. **Clone o Repositório:**
   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
   cd seu-repositorio
   ```

2. **Restore as Dependências:**
   ```bash
   dotnet restore
   ```

3. **Aplicar Migrações:**
   - Certifique-se de ter o Entity Framework Core CLI instalado globalmente.
     ```bash
     dotnet tool install --global dotnet-ef
     ```

   - Aplique as migrações para criar as tabelas no banco de dados.
     ```bash
     dotnet ef database update
     ```

4. **Execute a API:**
   ```bash
   dotnet run
   ```

A API estará disponível em `https://localhost:5001`. Certifique-se de ajustar a porta conforme necessário.

## Endpoints da API

- `GET /api/Cliente`: Exemplo de endpoint para recuperar dados.

---

