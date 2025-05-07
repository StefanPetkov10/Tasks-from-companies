class Program
{
    static void Main(string[] args)
    {
        int[] weights = { 26, 7, 10, 30, 5, 4 };
        int minimumCapacity = MinCapacityForTwoTrips(weights);
        Console.WriteLine("Minimum capacity required for two trips: " + minimumCapacity);
    }

    static int MinCapacityForTwoTrips(int[] weights)
    {
        Array.Sort(weights);
        Array.Reverse(weights);

        int firstTripIndex = 0;
        int secondTripIndex = weights.Length - 1;

        // Find the index where the sum of weights fits for two trips
        while (firstTripIndex < secondTripIndex)
        {
            int totalWeight = weights[firstTripIndex] + weights[secondTripIndex];
            if (totalWeight > 30)
            {
                // If the total weight exceeds 30, return it
                return totalWeight;
            }
            // Move to the next pair of items
            firstTripIndex++;
            secondTripIndex--;
        }

        // If no pair found with total weight exceeding 30, return the maximum weight
        return weights.Max();
    }
}

//Second Task
class Program
{
    static void Main()
    {
        int[] input = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        int rows = input[0];
        int cols = input[1];
        int days = input[2];

        char[,] cupboard = new char[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                cupboard[row, col] = 'O';
            }
        }

        int[] orange1 = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        int currentRow1 = orange1[0];
        int currentCol1 = orange1[1];

        int[] orange2 = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        int currentRow2 = orange2[0];
        int currentCol2 = orange2[1];

        cupboard[rows - currentRow1, currentCol1 - 1] = 'X';
        cupboard[rows - currentRow2, currentCol2 - 1] = 'X';

        while (days > 0)
        {
            char[,] nextCupboard = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    nextCupboard[row, col] = cupboard[row, col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (cupboard[row, col] == 'X')
                    {
                        if (row - 1 >= 0 && cupboard[row - 1, col] == 'O') // Up
                        {
                            nextCupboard[row - 1, col] = 'X';
                        }
                        if (row + 1 < rows && cupboard[row + 1, col] == 'O') // Down
                        {
                            nextCupboard[row + 1, col] = 'X';
                        }
                        if (col - 1 >= 0 && cupboard[row, col - 1] == 'O') // Left
                        {
                            nextCupboard[row, col - 1] = 'X';
                        }
                        if (col + 1 < cols && cupboard[row, col + 1] == 'O') // Right
                        {
                            nextCupboard[row, col + 1] = 'X';
                        }
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    cupboard[row, col] = nextCupboard[row, col];
                }
            }

            days--;
        }

        int healthyCount = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (cupboard[row, col] == 'O')
                {
                    healthyCount++;
                }
            }
        }

        Console.WriteLine(healthyCount + " healthy oranges");

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(cupboard[row, col]);
            }
            Console.WriteLine();
        }
    }
}
