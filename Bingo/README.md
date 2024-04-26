# Bingo!

## Fluxo da aplica��o:

- Prepara��o
- Jogo
- Final (Resultados)

## Estrutura de dados utilizada:

#### Prepara��o: Cria��o de jogadores e cartelas
Para lidar com os dados da partida foi utilizada uma estrutura baseada em matrizes:
- A quantidade de jogadores � armazenada em "playersCount" a identifica��o de cada jogador se da pelo indice dos vetores: 
	- O indice 0 de qualquer vetor representa o jogador 1
#### Jogo: Estrutura de dados e funcionalidades
- O vetor "playersCard" armazena as cartelas de cada jogador, sendo elas vetores de 5x5
- Os numeros a serem sorteados ficam no vetor "numbers", uma vez um sorteado o n�mero assume o valor de 0 (zeros n�o podem ser sorteados)
- A fun��o "drawNumber" sorteia um n�mero e "resetNumbers" restaura todos os n�meros de 1-100

# TODO:
- Fase de prepara��o:
	- Declarar quantos jogadores, quantas cartelas e seus nomes (ok)
	- Criar cartelas (ok)
	- Popular cartelas (ok)
- Fase de jogo:
	- Criar sorteador de numeros (x)
	- Criar validador de linhas e colunas ()
	- Identifica se j� houve uma linha ou coluna completa