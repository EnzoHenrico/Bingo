# Bingo!

## Fluxo da aplicação:

- Preparação
- Jogo
- Final (Resultados)

## Estrutura de dados utilizada:

#### Preparação: Criação de jogadores e cartelas
Para lidar com os dados da partida foi utilizada uma estrutura com base em indices:
- Cada jogador representa o indice inicial em todas as estruturas definidas no jogo.
- Para cada jogador o nome é armazenado no vetor "playersName", onde o nome do jogador 1 está no indice 0 desse mesmo veetor.
- Na estrutura "playersData" a segunda camada define cada dado do jogador, por exemplo: A camada de indice 0 controla as cartelas, caso seja necessario armazenar mais uma informação é só adicionar mais um indice.
- A matriz "cards" guarda as cartelas, para encontrar quais as cartelas do jogador 1 é necessário acessar as informações de cartela guardadas na "playersData".

# TODO:
- Fase de preparação ():
	- Declarar quantos jogadores, quantas cartelas e seus nomes (ok)
	- Criar cartelas (ok)
	- Popular cartelas ()
- Fase de jogo:
	- Criar sorteador de numeros ()
	- Criar iterador de cartelas ()
	- Criar validador de linhas e colunas ()