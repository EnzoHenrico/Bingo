// Atribuições independentes
using System.Data.Common;

int playersCount = 0, cardsCount = 0, lastCalledNumber = 0, round = 0;
bool match = false, playerMatechedInRound = false, lineScore = false, columnScore = false;
bool canLineScore = true, canColumnScore = true, calledBingo = false;
bool scoredLineThisRound = false, scoredColumnThisRound = false, bingoThisRound = false;
int[] numbers = new int[99];

// Solicita dados da partida
Console.WriteLine("┌----------------------------------------┐");
Console.WriteLine("|                                        | ");
Console.WriteLine("|  *  Bem vindo ao meu jogo de Bingo  *  |");
Console.WriteLine("|                                        | ");
Console.WriteLine("└----------------------------------------┘\n");
getRequiredInfo();

// Atribuições relativas a partida
string[] playersName = new string[playersCount];
int[] playersScore = new int[playersCount];
int[][,] playersCard = new int[playersCount * cardsCount][,];
int[][,] playersCardMask = new int[playersCount * cardsCount][,];
int[,] cardsIndex = new int[playersCount, cardsCount];

void getRequiredInfo()
{
    do
    { 
        Console.Write("Quantos jogadores vão participar? [   ]");
        (int left, int top) = Console.GetCursorPosition();
        Console.SetCursorPosition(left - 3, top);
        playersCount = int.Parse(Console.ReadLine());

        if (playersCount < 2)
        {
            Console.WriteLine("\n -- É necessário pelo menos 2 jogadores, tente novamente -- ");
        }
        Console.WriteLine();
    } while (playersCount < 2);
    do
    {
        Console.Write("Quantas cartelas por jogador? [   ]");
        (int left, int top) = Console.GetCursorPosition();
        Console.SetCursorPosition(left - 3, top);
        cardsCount = int.Parse(Console.ReadLine());

        if (cardsCount < 1)
        {
            Console.WriteLine("\n -- É necessário pelo menos 1 cartela por jogador, tente novamente -- ");
        }
        Console.WriteLine();
    }
    while (cardsCount < 1);
}

void inputNewPlayersNames()
{
    for (int i = 0; i < playersCount; i++)
    {
        do
        {
            Console.Write($"Qual nome dar para o jogador {i + 1}? [         ]");
            (int left, int top) = Console.GetCursorPosition();
            Console.SetCursorPosition(left - 9, top);
            string input = Console.ReadLine();

            if (input.Length > 2)
            {
                playersName[i] = input;
                break;
            }
            Console.WriteLine("\n -- Nome do jogador deve ter pelo menos 3 caracteres -- \n");
        }
        while (true);
        Console.WriteLine();
    }
    Console.WriteLine("\n -- Nomes atribuidos! -- \n");
}

void printPlayerCards(int player)
{
    int firstCardIndex = player * cardsCount;
    int lastCardIndex = firstCardIndex + cardsCount;

    for (int cardBorderUp =  0; cardBorderUp < cardsCount; cardBorderUp++)
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
                if (playersCardMask[card][line, column] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{playersCard[card][line, column]:00} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"{playersCard[card][line, column]:00} ");
                }
            }
            Console.Write("|  ");
        }
        Console.WriteLine();
        if (line < 4)
        {
            for (int cardBorderDiv = 0; cardBorderDiv  < cardsCount; cardBorderDiv ++)
            {
                Console.Write("├----┼----┼----┼----┼----┤  ");
            }
            Console.WriteLine();
        }
    }
    for (int cardBorderDown = 0; cardBorderDown < cardsCount; cardBorderDown++)
    {
        Console.Write("└----┴----┴----┴----┴----┘  ");
    }
    Console.WriteLine("\n");
}

int[,] generateNewCard()
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

int[,] generateNewCardMask()
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

void populatePlayersCard()
{
    for (int player = 0; player < playersCount; player++)
    {
        int playerFirstCardIndex = player * cardsCount;
        int playerLastCardIndex = playerFirstCardIndex + cardsCount;
        int playerCurrentCardIndex = 0;

        for (int currentCard = playerFirstCardIndex; currentCard < playerLastCardIndex; currentCard++)
        {
            playersCard[currentCard] = generateNewCard();
            playersCardMask[currentCard] = generateNewCardMask();
            cardsIndex[player, playerCurrentCardIndex] = currentCard;
            playerCurrentCardIndex++;
        }
    }
}

void printNumbers()
{
    Console.WriteLine();
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] != 0)
        { 
            Console.Write($"{numbers[i]:00} ");
        }
    }
    Console.WriteLine();
}

void resetNumbers()
{
    for (int i = 0; i < 99; i++)
    {
        numbers[i] = i + 1;
    }
}

int callUniqueNumber()
{   
    int calledNumber = 0;
    do
    {
        int randomNumber = new Random().Next(1, 99);
        if (numbers[randomNumber] != 0)
        {
            calledNumber = numbers[randomNumber];
            numbers[randomNumber] = 0;
            return calledNumber;
        }
    }
    while (calledNumber == 0);
    return calledNumber;
}

bool checkNumberMatch(int cardIndex, int calledNumber)
{
    for (int line = 0; line < 5; line++)
    {
        for (int column = 0; column < 5; column++)
        {
            if (playersCard[cardIndex][line, column] == calledNumber)
            {
                playersCardMask[cardIndex][line, column] = 1;
                return true;
            }
        }
    }
    return false;
}

bool checkPlayerLineScore(int cardIndex)
{
    for (int line = 0; line < 5; line++)
    {
        int lineScore = 0;
        for (int column = 0; column < 5; column++)
        {
            if (playersCardMask[cardIndex][line, column] == 1)
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

bool checkPlayerColumnScore(int cardIndex)
{
    for (int column = 0; column < 5; column++)
    {
        int columnScore = 0;
        for (int line = 0; line < 5; line++)
        {
            if (playersCardMask[cardIndex][line, column] == 1)
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

bool checkPlayerBingo(int cardIndex)
{
    for (int column = 0; column < 5; column++)
    {
        for (int line = 0; line < 5; line++)
        {
            if (playersCardMask[cardIndex][line, column] == 0)
            {
                return false;
            }
        }
    }
    return true;
}

void printScoreboard()
{
    Console.WriteLine("\n┌------------------------------------------┐");
    Console.WriteLine("| Nome do Jogador       | Pontuação        | ");
    Console.WriteLine("|------------------------------------------|");
    for (int player = 0; player < playersCount; player++)
    {
        Console.WriteLine($"| {playersName[player],-22}| {playersScore[player],-17}| ");
    }
    Console.WriteLine("└------------------------------------------┘\n");
}

// Iniciando variaveis
inputNewPlayersNames();
populatePlayersCard();
resetNumbers();

// Inicio do jogo
Console.Clear();
for (int player = 0; player < playersCount; player++)
{
    Console.WriteLine($"┌-> As cartelas de {playersName[player]} foram entregues \n|");
    printPlayerCards(player);
    Console.WriteLine();
}

do
{
    Console.WriteLine("\n └- Pressione qualquer tecla para sortear um número -┘ \n");
    Console.ReadKey();
    Console.Clear();
    
    // Sorteador
    lastCalledNumber = callUniqueNumber();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("┌---------------------┐");
    Console.WriteLine($"| Número sortedo: {lastCalledNumber,-4}|");
    Console.WriteLine("└---------------------┘\n");
    Console.ResetColor();

    for (int player = 0; player < playersCount; player++)
    {
        int firstCardIndex = player * cardsCount;
        int lastCardIndex = firstCardIndex + cardsCount;
        int currentCardIndex = 0;
        playerMatechedInRound = false;

        for (int card = firstCardIndex; card < lastCardIndex; card++)
        {
            int index = cardsIndex[player, currentCardIndex];
            match = checkNumberMatch(index, lastCalledNumber);
            if (match)
            {
                playerMatechedInRound = true;
                calledBingo = checkPlayerBingo(index);
                lineScore = checkPlayerLineScore(index);
                columnScore = checkPlayerColumnScore(index);

                if (canLineScore && lineScore)
                {
                    Console.Write($"      ┌-> Linha completa para {playersName[player]} ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("(+ 1 ponto)\n");
                    Console.ResetColor();
                    scoredLineThisRound = true;
                    playersScore[player] += 1;
                }
                if (canColumnScore && columnScore)
                {
                    Console.Write($"      ┌-> Coluna completa para {playersName[player]} ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("(+ 1 ponto)\n");
                    Console.ResetColor();
                    scoredColumnThisRound = true;
                    playersScore[player] += 1;
                }
                if (calledBingo)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"      ┌-> Bingo!! Cartela completa para {playersName[player]} (+3 pontos) \n");
                    Console.ResetColor();
                    bingoThisRound = true;
                    playersScore[player] += 3;
                }
            }
            currentCardIndex++;
        }
        if (playerMatechedInRound)
        {
            Console.WriteLine($"┌─> {playersName[player]} teve acertos nessa rodada!\n|");
        }
        else
        {
            Console.WriteLine($"┌─> {playersName[player]} não teve acertos nessa rodada\n|");
        }
        printPlayerCards(player);
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
        Console.WriteLine($"\n ┌- Fim de jogo! Esse é o resultado final -┐");
        printScoreboard();

        break;
    }
}
while (true);

// Interação final
Console.ReadKey();
Console.Clear();
printScoreboard();
