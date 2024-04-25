// Preparação
int playerCount = 0, lineLength = 0, columnLength = 0;
do
{
    Console.Write("Quantidade de jogadores:");
    playerCount = int.Parse(Console.ReadLine());

    if (playerCount < 2)
    {
        Console.WriteLine("2 jogadores ou mais\n");
    }
}
while (playerCount < 2);

string[] playersNames = new string[playerCount];
int[] playersCardCount = new int[playerCount];

// Funções
void setPlayersNames(int playerCount)
{
    for (int i = 0; i < playerCount; i++)
    {
        do
        {
            Console.Write($"Qual o nome do jogador {i + 1}:");
            string input = Console.ReadLine();

            if (input.Length > 2)
            {
                playersNames[i] = input;
                break;
            }
            else
            {
                Console.WriteLine("Nome do jogador deve ter pelo menos 3 caracteres.\n");
            }

        }
        while (true);
    }
}

void setPlayesCardCount(int playersCount)
{
    int cardCount = 0;
    for (int i = 0; i < playersCount; i++)
    {
        do
        {
            Console.Write($"Quantidade de cartelas do jogador {i}:");
            cardCount = int.Parse(Console.ReadLine());

            if (cardCount < 1)
            {
                Console.WriteLine("Pelo menos 1 cartela por jogador.\n");
            }
            else
            {
                playersCardCount[i] = cardCount;
                break;
            }
        }
        while (true);
    }
}
// test and log
setPlayersNames(playerCount);
setPlayesCardCount(playerCount);
for (int i = 0;i < playerCount;i++)
{
    Console.WriteLine($"{playersNames[i]} possui {playersCardCount[i]} cartelas.");
}

// Definição de cartelas

// Jogo
// Definição do sorteador
// 

// Exibição de resultados