# Bingo!

## Fluxo da aplicação:

- Preparação
- Jogo
- Final (Resultados)

## Estrutura de dados utilizada:

#### Preparação: Criação de jogadores e cartelas
Para lidar com os dados da partida foi utilizada uma estrutura baseada em matrizes:
- A quantidade de jogadores é armazenada em "playersCount" a identificação de cada jogador se da pelo indice dos vetores: 
	- O indice 0 de qualquer vetor representa o jogador 1
#### Jogo: Estrutura de dados e funcionalidades
- O vetor "playersCard" armazena as cartelas de cada jogador, sendo elas vetores de 5x5
- Os numeros a serem sorteados ficam no vetor "numbers", uma vez um sorteado o número assume o valor de 0 (zeros não podem ser sorteados)
- A função "drawNumber" sorteia um número e "resetNumbers" restaura todos os números de 1-100

# TODO:
- Fase de preparação:
	- Declarar quantos jogadores, quantas cartelas e seus nomes (ok)
	- Criar cartelas (ok)
	- Popular cartelas (ok)
- Fase de jogo:
	- Criar sorteador de numeros (x)
	- Criar validador de linhas e colunas ()
	- Identifica se já houve uma linha ou coluna completa