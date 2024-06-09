
# API de Livraria

Esta é uma API de cadastro de livros em uma livraria desenvolvida em C#.

A API fornece endpoints para criar (Post), ler (Get), atualizar (Put/Patch) e deletar (Delete) livros do catálogo.

## Funcionalidades

- Adicionar um novo livro
- Obter a lista de todos os livros
- Obter detalhes de um livro específico
- Atualizar informações de um livro
- Remover um livro do catálogo

## Tecnologias utilizadas

- C#
- ASP.NET Core
- Entity Framework Core
- MySQL

## Requisitos

- .NET 8.0 SDK ou superior
- MySQL

## Documentação da API

#### Retorna todos os itens

```http
  GET /livro
```


#### Retorna um item

```http
  GET /livro/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do item que você quer |


#### Adiciona um item

```http
  POST /livro
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `titulo`      | `string` | **Obrigatório**. O título do livro |
| `autor`       | `string` | **Obrigatório**. O nome do autor do livro |
| `anoPublicacao`      | `int` | **Obrigatório**. O ano de publicação do livro |
| `genero`      | `string` | **Obrigatório**. O gênero do livro |
| `preco`      | `double` | **Obrigatório**. O preço do livro |


#### Atualizar um item

```http
  PUT /livro/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do item que você quer atualizar |

```http
  PATCH /livro/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do item que você quer atualizar |


#### Remover um item

```http
  DELETE /livro/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do item que você quer deletar |
