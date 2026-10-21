# ExemploEF — Atividade Prática 05

**Aluno(a):** [preencha seu nome]  
**Exercício:** Atividade Prática 05 – Modelo MVC com Entity Framework (PWBE)

## Objetivo
Ampliar uma aplicação ASP.NET Core MVC com Entity Framework, implementando CRUD de Categorias e Produtos e o relacionamento entre essas entidades.

## Aplicação
O projeto contém Models para Cliente, Categoria e Produto; Context com Entity Framework Core; Controllers MVC e Views Razor para listar, criar, consultar, editar e excluir registros. Produto pertence a uma Categoria por meio de `CategoriaId`; as telas de produtos exibem o nome da categoria. O banco é SQL Server LocalDB e as tabelas são `tbClientes`, `tbCategorias` e `tbProdutos`.

## Requisitos
- .NET 10 SDK
- SQL Server LocalDB (ou ajuste a connection string em `appsettings.json`)
- Visual Studio 2022 ou terminal com .NET CLI

## Como executar
1. Abra `ExemploEF.slnx` no Visual Studio ou abra a pasta `ExemploEF` como projeto.
2. Restaure os pacotes NuGet.
3. No Console do Gerenciador de Pacotes, selecione `ExemploEF` como projeto padrão e execute `Add-Migration InitialCreate` e depois `Update-Database`. Se estiver usando o terminal, execute `dotnet ef migrations add InitialCreate` e `dotnet ef database update` dentro da pasta do projeto (instale a ferramenta `dotnet-ef` se necessário).
4. Execute o projeto com F5 ou `dotnet run`.
5. Entre em Categorias e cadastre ao menos três categorias (Alimentos, Bebidas e Limpeza). Depois, cadastre cinco produtos distribuídos entre as categorias.

## Observação
O projeto foi montado a partir do arquivo de solução enviado, que aponta para `ExemploEF/ExemploEF.csproj`. Como o arquivo `.slnx` não continha o código-fonte anterior, esta pasta inclui uma implementação completa e autônoma com os três CRUDs. O banco é criado/aplicado por migrations; não é necessário executar `EnsureCreated`.
