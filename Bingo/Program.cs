int playersCount = 0; 
int cardsCount = 0;

do
{
    Console.Write("Quantidade de jogadores:");
    playersCount = int.Parse(Console.ReadLine());

    if (playersCount < 2)
    {
        Console.WriteLine("2 jogadores ou mais\n");
    }

    Console.Write("Quantidade de cartelas por jogador:");
    cardsCount = int.Parse(Console.ReadLine());

    if (cardsCount < 1)
    {
        Console.WriteLine("1 cartelas ou mais\n");
    }

}
while (playersCount < 2);

string[] playersName = new string[playersCount];
int[][,] playersCard = new int[playersCount * cardsCount][,];

// Players
void printPlayersList()
{
    for (int i = 0; i < playersCount; i++)
    {
        Console.WriteLine($"- {playersName[i]}");
    }
}
string[] inputNewPlayersNames(int playerCount)
{
    string[] playersName = new string[playersCount];
    for (int i = 0; i < playerCount; i++)
    {
        do
        {
            Console.Write($"Qual o nome do jogador {i + 1}:");
            string input = Console.ReadLine();

            if (input.Length > 2)
            {
                playersName[i] = input;
                break;
            }
            else
            {
                Console.WriteLine("Nome do jogador deve ter pelo menos 3 caracteres.\n");
            }

        }
        while (true);
    }
    return playersName;
}

// Cards
void printCard(int cardIndex)
{
    Console.WriteLine();
    for (int line = 0; line < 5; line++)
    {
        for (int column = 0; column < 5; column++)
        {
            Console.Write($"{playersCard[cardIndex][line, column]:00} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] populateCard(int[,] card)
{
    int[] tempSequencialNumbers = new int[99];
    for (int i = 0;i < 99;i++)
    {
        tempSequencialNumbers[i] = i + 1;
    }

    for (int line = 0; line < 5; line++)
    {
        for (int column = 0; column < 5; column++)
        {
            int randomIndex = new Random().Next(0, 99);
            while (tempSequencialNumbers[randomIndex] == 0)
            {
                randomIndex = new Random().Next(0, 99);
            }
            card[line, column] = tempSequencialNumbers[randomIndex];
            tempSequencialNumbers[randomIndex] = 0;
        }

    }
    return card;
}


Console.WriteLine("\nCriar jogadores:");
playersName = inputNewPlayersNames(playersCount);
printPlayersList();

Console.WriteLine("\nCriar cartelas:");
for (int player = 0; player < playersCount; player++)
{
    int firstCardIndex = player * cardsCount;
    int lastCardIndex = firstCardIndex + cardsCount;
    
    // Popula e imprime a cartela
    Console.WriteLine($"\nCartelas de {playersName[player]}:");
    for (int i = firstCardIndex; i < lastCardIndex; i++)
    {
        playersCard[i] = populateCard(new int[5, 5]);
        printCard(i);
    }
}

