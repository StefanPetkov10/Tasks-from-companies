namespace Test3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> rows = new List<string> { "5195", "7533", "2468" };
            int sum = SumOfDifferences(rows);
            Console.WriteLine("Sum: " + sum); // Output: Sum: 18
        }

        static int SumOfDifferences(List<string> rows)
        {
            int totalSum = 0;
            foreach (string row in rows)
            {
                string[] numbersAsString = row.Split();
                int maxNum = int.MinValue;
                int minNum = int.MaxValue;
                foreach (string numStr in numbersAsString)
                {
                    int num = int.Parse(numStr);
                    if (num > maxNum)
                    {
                        maxNum = num;
                    }
                    if (num < minNum)
                    {
                        minNum = num;
                    }
                }
                int difference = maxNum - minNum;
                totalSum += difference;
            }
            return totalSum;
        }
    }

}
