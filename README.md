# Bingo!
Jogo de Bingo para terminal com quantidade vari�vel de jogadores e cartelas.

![Preview do jogo](preview_terminal.jpeg)

## Fluxo de desenvolvimento:
- Defini��o de dados necess�rios
- L�gica dos sorteios e confer�ncia das cartelas 
- Controle das vari�veis da rodada
- Controle de parada e final da partida
- Exibi��o dos resultados

## Estrutura de dados utilizada:
Para lidar com os dados da partida foi utilizada uma estrutura baseada em vetores sem a utiliza��o de objetos.

#### Jogadores: 
- A quantidade de jogadores � armazenada em "playersCount", a ordem que s�o inseridos os jogadores define o seu identificador
- O indice 0 de qualquer vetor que carrega dados representa o primeiro jogador inserido e assim sucetivamente
- Cada jogador possui um conjunto de cartelas e um nome que � armazenado no vetor "playersName" 
- A quantidade de cartelas � armazenada em "cardsCount" que � definida no inicio do c�digo assim como o n�mero de jogadores: 

#### Cartelas
- O vetor de matrizes(5x5) "playerCards" armazena todas as cartelas de todos os jogadores, cada matriz � uma cartela
- As cartelas s�o criadas pela fun��o "PopulateAllPlayerCards" que na sua execu��o popula as cartelas com n�meros aleat�rios n�o repetidos
- Cada cartela possui uma m�scara, armazenada em "playerCardsMask", as m�scaras s�o matrizes de 5x5 somente com 0s e 1s
- Cada acerto na cartela do jogador � marcado na m�scara com o n�mero 1, sendo assim avaliado os n�meros na cartela e marcado na m�scara para persist�ncia dos dados
- O vetor "cardsIndexList" armazena as posi��es das cartelas de cada jogador para que n�o fosse necess�rio criar mais uma profundida em "playerCards"

#### Sorteador e Placar
- "numbersToBeDrawn" � um vetor com n�meros de 1 a 99 que n�o se repetem
- Ao sortear um n�mero com a fun��o "CallNumberFromNumbersToDraw" o sorteado � substituido por 0 e ignorado no pr�ximo sorteio
- A fun��o "resetNumbers" restaura todos os n�meros de 1 a 99
- No vetor "playerPoints" cada indice armazena a pontua��o de um jogador
- A exibi��o do scoreboard final � feita com a fun��o "PrintScoreboard"
