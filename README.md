# Resumo
Projeto desenvolvido para **WK Technology** com intuito de apresentar conhecimento e skills de desenvolvimento.

# Instalação
No arquivo `appsettings.json` dos projetos **"WK.TechnicalTest.Api"** e **"WK.TechnicalTest.Web"** necessário alterar a connection string para sua local e executar o comando do Entity Framework no `Package Manager Console`.

    update-database

Para execução do projeto web necessário definir a url de execução da API,  adicionando trecho conforme exemplo no arquivo `appsettings.json`  do projeto **"WK.TechnicalTest.Web"**:

    "ApiSettings": {
        "BaseUri": "{UrlApi}"
      }

# Tecnologias e outros

### Padrão de projeto
Utilizado repository pattern como design pattern principal no projeto.

### Banco de dados
Utilizado banco de dados MySQL como banco e o ORM Entity Framework.

### Bibliotecas e plugins
Neste projeto foi utilizado algumas bibliotecas como Jquery, Bootstrap, AutoMapper.
Também foi utilizado o plugin de javascript para geração de tabelas chamado [DataTables](https://datatables.net/ "DataTables"). 
