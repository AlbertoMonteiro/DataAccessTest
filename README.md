# O que mudou

Essa é uma versão que usa o banco Postgress

Versão usa .NET Core 3.1

```xml
<PackageReference Include="Dapper" Version="2.0.35" />
<PackageReference Include="FluentNHibernate" Version="2.1.2" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="3.1.5" />
<PackageReference Include="NHibernate" Version="5.2.7" />
<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="3.1.4" />
<PackageReference Include="System.Data.SqlClient" Version="4.8.1" />
```

# Resultados

O teste consiste em trazer todas as linhas da tabela Customer que possui pouco mais de 1 milhão de linhas(1.009.090) e converte para a classe Customer

| Elapsed          | Title                 |
| ---              | ---                   |
| 00:00:03.8626074 | ADO Puro              |
| 00:00:03.0026181 | Dapper                |
| 00:00:09.9934731 | Entity Framework      |
| 00:00:03.3130720 | Entity Framework Fast |
| 00:00:15.1031657 | NHibernate            |

# Obs

Para acessar a versão com Sql Server, só alterar para o branch `master`