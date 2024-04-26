# Bingo!

## Fluxo da aplica��o:

- Prepara��o
- Jogo
- Final (Resultados)

## Estrutura de dados utilizada:

#### Prepara��o: Cria��o de jogadores e cartelas
Para lidar com os dados da partida foi utilizada uma estrutura com base em indices:
- Cada jogador representa o indice inicial em todas as estruturas definidas no jogo.
- Para cada jogador o nome � armazenado no vetor "playersName", onde o nome do jogador 1 est� no indice 0 desse mesmo veetor.
- Na estrutura "playersData" a segunda camada define cada dado do jogador, por exemplo: A camada de indice 0 controla as cartelas, caso seja necessario armazenar mais uma informa��o � s� adicionar mais um indice.
- A matriz "cards" guarda as cartelas, para encontrar quais as cartelas do jogador 1 � necess�rio acessar as informa��es de cartela guardadas na "playersData".

# TODO:
- Fase de prepara��o ():
	- Declarar quantos jogadores, quantas cartelas e seus nomes (ok)
	- Criar cartelas (ok)
	- Popular cartelas ()
- Fase de jogo:
	- Criar sorteador de numeros ()
	- Criar iterador de cartelas ()
	- Criar validador de linhas e colunas ()