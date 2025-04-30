namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> rows = new List<string> { "1abc2", "qwer2ty0uiop", "e1x2a3m4p5l6e" };
            int sum = SumOfNumbers(rows);
            Console.WriteLine("Sum: " + sum); // Output: Sum: 48
        }

        static int SumOfNumbers(List<string> rows)
        {
            int totalSum = 0;
            foreach (string row in rows)
            {
                int firstDigit = -1;
                int lastDigit = -1;
                foreach (char c in row)
                {
                    if (char.IsDigit(c))
                    {
                        if (firstDigit == -1)
                        {
                            firstDigit = int.Parse(c.ToString());
                        }
                        lastDigit = int.Parse(c.ToString());
                    }
                }
                if (firstDigit != -1 && lastDigit != -1)
                {
                    int rowSum = firstDigit * 10 + lastDigit;
                    totalSum += rowSum;
                }
            }
            return totalSum;
        }
    }

}
