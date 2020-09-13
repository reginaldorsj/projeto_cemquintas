# Projeto CemQuintas
Sistema para cadastramento de sepultamentos e exumações para o Cemitério Quintas dos Lázaros, Salvador-Ba! Em produção desde 2006 tendo sua primeira versão desenvolvida em **ASP.NET WebForms**, com regras de negócio **(BO)** e acesso a dados **(DAO)** separados em camadas. Além disso, utilizamos **NHibernate** para ORM com o banco de dados **(Firebird)**. Em 2020 arquitetura dessa aplicação foi modificada. **Angular 9** passou a ser utilizado no front-end da aplicação e, então, uma API precisou ser inserida. Ainda em ASP.NET, desenvolvemos uma **WEB API** para fazer o middleware entre o front-end e as regras de negócio da aplicação.

[![CemQuintas Front](http://sis.saude.ba.gov.br/CemQuintas/assets/images/cemquintas.png "CemQuintas Front")](sis.saude.ba.gov.br/CemQuintas/assets/images/cemquintas.png "CemQuintas Front")

### Segue resumo dos principais recursos utilizados na aplicação:
- No front-end: [Token Validation](http://www.advancesharp.com/blog/1237/angular-6-web-api-2-bearer-token-authentication-add-to-header-with-httpinterceptor "Token Validation"), [PrimeNG Components](https://www.primefaces.org/primeng/ "PrimeNG Components") based, [ngx-infinite-scroll](https://www.npmjs.com/package/ngx-infinite-scroll/ "ngx-infinite-scroll"), PDF Viewer (Blob), Promisses, Services, Models, Routes, etc.
- No back-end: ASP.NET Web API, [OAuth Web API Token based authentication](http://www.advancesharp.com/blog/1216/oauth-web-api-token-based-authentication-with-custom-database "OAuth Web API Token based authentication"), Business Objects Layer (BO), Data Access Layer (DAO), NHibernate ORM, Relatórios em PDF e XLS, etc.
- [Firebird Database 2.5](https://firebirdsql.org/ "Firebird Database 2.5")
