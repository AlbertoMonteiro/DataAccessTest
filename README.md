# O que mudou
O teste anterior tinha sido feito com as seguintes opções:

Usando .NET Framework 4.5

```xml
<package id="Dapper" version="1.42" targetFramework="net45" />
<package id="EntityFramework" version="6.1.3" targetFramework="net45" />
<package id="FluentNHibernate" version="2.0.1.0" targetFramework="net45" />
<package id="Iesi.Collections" version="4.0.1.4000" targetFramework="net45" />
<package id="NHibernate" version="4.0.3.4000" targetFramework="net45" />
```

Agora essa nova versão usa .NET Core 3.1

```xml
<PackageReference Include="Dapper" Version="2.0.35" />
<PackageReference Include="FluentNHibernate" Version="2.1.2" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="3.1.5" />
<PackageReference Include="NHibernate" Version="5.2.7" />
<PackageReference Include="System.Data.SqlClient" Version="4.8.1" />
```

# Resultados

O teste consiste em trazer todas as linhas da tabela Customer que possui pouco mais de 1 milhão de linhas(1.009.090) e converte para a classe Customer

 | Elapsed          | Title                 |
 | --- | --- |
 | 00:00:02.5565161 | ADO Puro              |
 | 00:00:02.6706603 | Dapper                |
 | 00:00:09.8713832 | Entity Framework      |
 | 00:00:02.9859552 | Entity Framework Fast |
 | 00:00:12.9286202 | NHibernate            |

# Obs

Para acessar a versão antiga, só alterar para o branch `old-version`