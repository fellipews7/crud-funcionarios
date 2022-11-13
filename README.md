# crud-funcionarios
CRUD Criado para um teste. O objetivo projeto é:

Teste Backend

	⁃	Criar um repositório no Github e postar a solução.

Requisitos:
 - Criar uma Solution.
 - Criar um banco de dados SQL Server
 - Criar uma API
 - Desenvolver um CRUD

API deve ter:
	◦	Autenticação
	◦	Um CRUD para o cadastro de funcionário (Os campos estão no fim do arquivo)
	◦	Injeção de dependência
	◦	Necessário usar .net core 6 e EF Core

PARA AS ALTERAÇÕES DE DATABASE
-Utilizar o padrão code first

Escopo:

Desejo realizar um cadastro de funcionário no meu sistema, para isso os campos que devem ser salvos são:
	◦	Nome
◦	Idade
◦	Imagem
	◦	Documento Federal (cpf ou cnpj)
	◦	Tipo de pessoa (Pessoa física ou Pessoa Jurídica)
	◦	Enderecos
	◦	Rua
	◦	Bairro
	◦	UF
	◦	Cidade
	◦	Complemento
	◦	Endereço Principal
	◦	Contato
	◦	Número
	◦	Email

Validações

Caso a pessoa seja pessoa física o documento federal deve ser validado se é um cpf valido, e se for pessoa jurídica deve ser validado como um cnpj valido.
A idade precisa ser maior que 16 anos.
Email deve ser um endereço valido.
Número de contato não pode aceitar letras.
Somente um endereço principal.

Testes unitários são opcionais.


