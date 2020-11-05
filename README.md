# Learn
<p>Projeto para fazer um crud de produtos e categorias!</p>
##Iniciando
<p>Os próximos tópicos o guiarão para que você tenha uma cópia deste projeto em sua máquina local funcionando, pronto para desenvolver e executar testes.<p>

## Pré-requisitos
+ .NET Core SDK 3.1
+ PostgreSQL 12

## Instalação
<p>Passo a passo para executar a aplicação</p>

<p>Clone o repositório em seu computador:</p>

```https://github.com/Scalfi/Learn.git```

<p>Entre na pasta do repositorio e rode o codigo</p>

```dotnet restore```


#### Banco de dados

<p>Para configurar o banco de dados, selecione o appsettings e na linha DatabaseConection configure as credencias de conexão com seu banco de dados postgres<p>

```"DatabaseConection": "User ID =postgres;Password=senha;Server=localhost;Port=5432;Database=paschoalotto;Integrated Security=true;Pooling=true;"```

<p>Para criar as tabelas no banco de dados você deve executar os seguintes comandos.</p>
+ dotnet ef migrations add InitialCreate
+ dotnet ef database update
<p>  Com programa restaurado e banco de dados configurado, rode o comando abaixo para iniciar o sistema<p>

```dotnet run```
