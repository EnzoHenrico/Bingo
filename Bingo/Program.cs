// Preparação
int playerCount = 0;
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

void logMatrix(int[,] iMatrix)
{

    for (int i = 0; i < iMatrix.Length; i++)
    {
        for (int j = 0; j < iMatrix.GetLength(i); j++)
        {
            Console.WriteLine(iMatrix[i,j]);
        }
    }
}

void setPlayersNames()
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

// test and log
setPlayersNames();
foreach (var item in playersNames)
{
    Console.WriteLine(item);
}

// Definição de cartelas

// Jogo
// Definição do sorteador
// 

// Exibição de resultados