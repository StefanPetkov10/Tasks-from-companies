namespace Test4
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "123";
            string text = "aaa321aaa";
            int count = CountPatternOccurrences(pattern, text);
            Console.WriteLine("Count: " + count); // Output: Count: 1
        }

        static int CountPatternOccurrences(string pattern, string text)
        {
            int patternLength = pattern.Length;
            int textLength = text.Length;
            int count = 0;

            for (int i = 0; i <= textLength - patternLength; i++)
            {
                if (text.Substring(i, patternLength) == pattern)
                {
                    count++;
                }
            }

            return count;
        }
    }

}
