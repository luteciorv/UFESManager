# UFESManager
Aplicação dos conhecimentos de EntityFramework Code-First no .Net Framework

### Composição
> O projeto utiliza uma organização parecida com a MVC, utilizando o EntityFramework. Isto significa que ele apresenta as pastas:
> * Models: Que guardam as classes que representam as tabelas do banco de dados
> * Services: Classes de serviços que realizam operações nas respectivas tabelas (Ex: Classe Department e Service DepartmentService)
> * Migrations: Controle das alterações nas tabelas feitas ao longo do desenvolvimento do projeto e também povoamento do banco de dados
> * Data: Classe context do projeto, isto é, a classe que vai o meio de campo entre o projeto e o banco de dados

### Ferramental
> * .Net Framework
> * EntityFramework
> * Conexão local com o banco de dados SQLServer
> * Preenchimento de informações no banco de dados na classe Seed dentro de Configuration.cs
> * Organização semelhante ao MVC

### Intuito
Realizei esse projeto visando testar o comportamento do EntityFramework e quais ferramentas eu poderia utilizar ao longo do desenvolvimento.
Inúmeros testes nas tabelas foram feitos, tais como adicionar uma nova coluna, alterar certos valores da chave primária, adição de nova tabela e etc.
A ideia geral era substituir o uso dos comandos diretos do SQL pelos comandos do EntityFramework

### Teste por sí mesmo
Algumas partes do código não foram totalmente terminadas. Sinta se livre para continuar se assim desejar. Com a organização dos códigos, comentários e o ferramental
presente, será bem tranquil compreender o padrão e fazer por sí mesmo. Dito isso, para testar a aplicação, siga os passos abaixo:
> * Execute o "program.cs"
> * Selecione a opção **3** (As demais não foram implementadas, como dito anteriormente)
> * Selecione quais opções desejar, dentro de 1 ~ 5

### Tela

