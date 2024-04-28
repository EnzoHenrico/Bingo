// Atribuições independentes
int numberOfPlayers = 0, numberOfCards = 0, lastCalledNumber = 0;
bool score = false, lineScore = false, columnScore = false;
bool scoredNumberThisRound = false, scoredLineThisRound = false, scoredColumnThisRound = false, bingoThisRound = false;
bool canLineScore = true, canColumnScore = true, calledBingo = false;

// Solicita dados da partida
Console.WriteLine("┌----------------------------------------┐");
Console.WriteLine("|                                        | ");
Console.WriteLine("|  *  Bem vindo ao meu jogo de Bingo  *  |");
Console.WriteLine("|                                        | ");
Console.WriteLine("└----------------------------------------┘\n");
GetRequiredData();

// Atribuições relativas a partida
int[] numbersToBeDrawn = new int[99];
string[] playerNames = new string[numberOfPlayers];
int[][,] playerCards = new int[numberOfPlayers * numberOfCards][,];
int[][,] playerCardsMask = new int[numberOfPlayers * numberOfCards][,];
int[,] cardsIndexList = new int[numberOfPlayers, numberOfCards];
int[] playerPoints = new int[numberOfPlayers];

void GetRequiredData()
{
    do
    { 
        Console.Write("Quantos jogadores vão participar? [   ]");
        (int left, int top) = Console.GetCursorPosition();
        Console.SetCursorPosition(left - 3, top);
        numberOfPlayers = int.Parse(Console.ReadLine());

        if (numberOfPlayers < 2)
        {
            Console.WriteLine("\n -- É necessário pelo menos 2 jogadores, tente novamente -- ");
        }
        Console.WriteLine();
    } while (numberOfPlayers < 2);
    do
    {
        Console.Write("Quantas cartelas por jogador? [   ]");
        (int left, int top) = Console.GetCursorPosition();
        Console.SetCursorPosition(left - 3, top);
        numberOfCards = int.Parse(Console.ReadLine());

        if (numberOfCards < 1)
        {
            Console.WriteLine("\n -- É necessário pelo menos 1 cartela por jogador, tente novamente -- ");
        }
        Console.WriteLine();
    }
    while (numberOfCards < 1);
}

void InputPlayerNames()
{
    for (int i = 0; i < numberOfPlayers; i++)
    {
        do
        {
            Console.Write($"Qual nome dar para o jogador {i + 1}? [         ]");
            (int left, int top) = Console.GetCursorPosition();
            Console.SetCursorPosition(left - 9, top);
            string input = Console.ReadLine();

            if (input.Length > 2)
            {
                playerNames[i] = input;
                break;
            }
            Console.WriteLine("\n -- Nome do jogador deve ter pelo menos 3 caracteres -- \n");
        }
        while (true);
        Console.WriteLine();
    }
    Console.WriteLine("\n -- Nomes atribuidos! -- \n");
}

void PrintPlayerCards(int player)
{
    int firstCardIndex = player * numberOfCards;
    int lastCardIndex = firstCardIndex + numberOfCards;

    for (int cardBorderUp =  0; cardBorderUp < numberOfCards; cardBorderUp++)
    {
        Console.Write("┌----┬----┬----┬----┬----┐  ");
    }
    Console.WriteLine();
    for (int line = 0; line < 5; line++)
    {
        for (int card = firstCardIndex; card < lastCardIndex; card++)
        {
            for (int column = 0; column < 5; column++)
            {
                Console.Write("| ");
                if (playerCardsMask[card][line, column] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{playerCards[card][line, column]:00} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"{playerCards[card][line, column]:00} ");
                }
            }
            Console.Write("|  ");
        }
        Console.WriteLine();
        if (line < 4)
        {
            for (int cardBorderDiv = 0; cardBorderDiv  < numberOfCards; cardBorderDiv ++)
            {
                Console.Write("├----┼----┼----┼----┼----┤  ");
            }
            Console.WriteLine();
        }
    }
    for (int cardBorderDown = 0; cardBorderDown < numberOfCards; cardBorderDown++)
    {
        Console.Write("└----┴----┴----┴----┴----┘  ");
    }
    Console.WriteLine("\n");
}

int[,] CreateCard()
{
    int[,] card = new int[5, 5];
    int[] tempSequencialNumbers = new int[99];

    for (int i = 0;i < 99;i++)
    {
        tempSequencialNumbers[i] = i + 1;
    }

    for (int line = 0; line < 5; line++)
    {
        for (int column = 0; column < 5; column++)
        {
            int randomIndex = new Random().Next(1, 99);
            while (tempSequencialNumbers[randomIndex] == 0)
            {
                randomIndex = new Random().Next(1, 99);
            }
            card[line, column] = tempSequencialNumbers[randomIndex];
            tempSequencialNumbers[randomIndex] = 0;
        }

    }
    return card;
}

int[,] CreateCardMask()
{
    int[,] card = new int[5, 5];
    for (int line = 0; line < 5; line++)
    {
        for (int column = 0; column < 5; column++)
        {
            card[line, column] = 0;
        }
    }
    return card;
}

void PopulateAllPlayerCards()
{
    for (int player = 0; player < numberOfPlayers; player++)
    {
        int playerFirstCardIndex = player * numberOfCards;
        int playerLastCardIndex = playerFirstCardIndex + numberOfCards;
        int playerCurrentCardIndex = 0;

        for (int currentCard = playerFirstCardIndex; currentCard < playerLastCardIndex; currentCard++)
        {
            playerCards[currentCard] = CreateCard();
            playerCardsMask[currentCard] = CreateCardMask();
            cardsIndexList[player, playerCurrentCardIndex] = currentCard;
            playerCurrentCardIndex++;
        }
    }
}

void ResetNumbersToDraw()
{
    for (int i = 0; i < 99; i++)
    {
        numbersToBeDrawn[i] = i + 1;
    }
}

int CallNumberFromNumbersToDraw()
{   
    int calledNumber = 0;
    do
    {
        int randomNumber = new Random().Next(1, 99);
        if (numbersToBeDrawn[randomNumber] != 0)
        {
            calledNumber = numbersToBeDrawn[randomNumber];
            numbersToBeDrawn[randomNumber] = 0;
            return calledNumber;
        }
    }
    while (calledNumber == 0);
    return calledNumber;
}

bool CheckScoreInCard(int cardIndex, int calledNumber)
{
    for (int line = 0; line < 5; line++)
    {
        for (int column = 0; column < 5; column++)
        {
            if (playerCards[cardIndex][line, column] == calledNumber)
            {
                playerCardsMask[cardIndex][line, column] = 1;
                return true;
            }
        }
    }
    return false;
}

bool CheckLineScoreInCard(int cardIndex)
{
    for (int line = 0; line < 5; line++)
    {
        int lineScore = 0;
        for (int column = 0; column < 5; column++)
        {
            if (playerCardsMask[cardIndex][line, column] == 1)
            {
                lineScore++;
                if (lineScore == 5)
                {
                    return true;
                }
            }
        }
    }

    return false;
}

bool CheckColumnScoreInCard(int cardIndex)
{
    for (int column = 0; column < 5; column++)
    {
        int columnScore = 0;
        for (int line = 0; line < 5; line++)
        {
            if (playerCardsMask[cardIndex][line, column] == 1)
            {
                columnScore++;
                if (columnScore == 5)
                {
                    return true;
                }
            }
        }
    }
    return false;
}

bool CheckBingoInCard(int cardIndex)
{
    for (int column = 0; column < 5; column++)
    {
        for (int line = 0; line < 5; line++)
        {
            if (playerCardsMask[cardIndex][line, column] == 0)
            {
                return false;
            }
        }
    }
    return true;
}

void PrintScoreboard()
{
    Console.WriteLine("\n┌------------------------------------------┐");
    Console.WriteLine("| Nome do Jogador       | Pontuação        | ");
    Console.WriteLine("|------------------------------------------|");
    for (int player = 0; player < numberOfPlayers; player++)
    {
        Console.WriteLine($"| {playerNames[player],-22}| {playerPoints[player],-17}| ");
    }
    Console.WriteLine("└------------------------------------------┘\n");
}

// Iniciando variaveis
InputPlayerNames();
PopulateAllPlayerCards();
ResetNumbersToDraw();

// Entrega das cartelas para os jogadores
Console.Clear();
for (int player = 0; player < numberOfPlayers; player++)
{
    Console.WriteLine($"┌-> As cartelas de {playerNames[player]} foram entregues \n|");
    PrintPlayerCards(player);
    Console.WriteLine();
}

// Inicício dos rounds
do
{
    Console.WriteLine("\n └- Pressione qualquer tecla para sortear um número -┘ \n");
    Console.ReadKey();
    Console.Clear();
    
    // Sortear números
    lastCalledNumber = CallNumberFromNumbersToDraw();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("┌---------------------┐");
    Console.WriteLine($"| Número sortedo: {lastCalledNumber,-4}|");
    Console.WriteLine("└---------------------┘\n");
    Console.ResetColor();

    // Conferir cartelas
    for (int player = 0; player < numberOfPlayers; player++)
    {
        int firstCardIndex = player * numberOfCards;
        int lastCardIndex = firstCardIndex + numberOfCards;
        int currentCardIndex = 0;
        scoredNumberThisRound = false;

        for (int card = firstCardIndex; card < lastCardIndex; card++)
        {
            int index = cardsIndexList[player, currentCardIndex];
            score = CheckScoreInCard(index, lastCalledNumber);
            if (score)
            {
                scoredNumberThisRound = true;
                calledBingo = CheckBingoInCard(index);
                lineScore = CheckLineScoreInCard(index);
                columnScore = CheckColumnScoreInCard(index);

                if (canLineScore && lineScore)
                {
                    scoredLineThisRound = true;
                    playerPoints[player] += 1;
                    
                    Console.Write($"      ┌-> Linha completa para {playerNames[player]} ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("(+ 1 ponto)\n");
                    Console.ResetColor();
                }
                if (canColumnScore && columnScore)
                {
                    scoredColumnThisRound = true;
                    playerPoints[player] += 1;

                    Console.Write($"      ┌-> Coluna completa para {playerNames[player]} ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("(+ 1 ponto)\n");
                    Console.ResetColor();
                }
                if (calledBingo)
                {
                    bingoThisRound = true;
                    playerPoints[player] += 3;
                    
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"      ┌-> Bingo!! Cartela completa para {playerNames[player]} (+3 pontos) \n");
                    Console.ResetColor();
                }
            }
            currentCardIndex++;
        }

        if (scoredNumberThisRound)
        {
            Console.WriteLine($"┌─> {playerNames[player]} teve acertos nessa rodada!\n|");
        }
        else
        {
            Console.WriteLine($"┌─> {playerNames[player]} não teve acertos nessa rodada\n|");
        }
        PrintPlayerCards(player);
    }
    if (scoredLineThisRound)
    {
        canLineScore = false;
    }
    if (scoredColumnThisRound)
    {
        canColumnScore = false;
    }
    if (bingoThisRound)
    {
        Console.ReadKey();
        Console.WriteLine("\n ┌- Fim de jogo! Esse é o resultado final -┐");
        PrintScoreboard();

        break;
    }
}
while (true);

// Interação final
Console.ReadKey();
Console.Clear();
PrintScoreboard();
