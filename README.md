# Desafio 7 Days of C# - Tamagotchi Pokémon
Esse desafio de 7 dias visa implementar uma nova versão do Tamagotchi usando a API do Pokémon para buscar os pokémons que serão mascotes e implementar interações com eles através de comunicação com a API, utilizando o JSON obtido.

## Dia 1 (branch master)
No primeiro dia, é preciso iniciar uma aplicação back-end em C#, consumindo a API do Pokémon!
- [x] Desenvolver uma funcionalidade onde o jogador poderá acessar uma lista de opções de espécies de pokémons
- [x] Visualizar suas características para facilitar sua escolha antes da adoção.

## Dia 2 (branch dia/2)
O desafio é extrair as características relevantes da resposta JSON e exibi-las de maneira organizada.
- [x] Criar uma classe que representa um mascote e coloque os atributos com o mesmo nome e tipo de dados dos campos retornados no JSON
- [x] Converter o resultado da API neste objeto criado

## Dia 3 (branch dia/3)
O desafio de hoje é trabalhar a saída de dados através da construção de um menu divertido para dar vida ao aplicativo de console. 
A ideia será criar um menu interativo, com opções e mensagens divertidas para o usuário.
- [x] Dar boas vindas ao usuário, ler o nome da pessoa e dados relevantes
- [x] Exibir um menu que possibilite: “Adoção de mascotes”, “Ver mascotes adotados” e “Sair do Jogo”

### O que é esperado do menu de adoção?
- [x] Que o jogador possa escolher uma espécie e ver ou não suas características antes de adotá-lo
- [x] Que o jogador possa ver detalhes sobre as espécies que desejar antes de fazer a escolha da adoção
- [x] Que caso o jogador goste das características do mascote, ele possa realizar a adoção do mesmo