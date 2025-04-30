namespace Test1
{
    class Program
    {
        static int ValidatePassSentences(List<string> passSentences)
        {
            int validCount = 0;
            foreach (string sentence in passSentences)
            {
                string[] words = sentence.Split();
                HashSet<string> uniqueWords = new HashSet<string>(words);
                if (words.Length == uniqueWords.Count)
                {
                    validCount++;
                }
            }
            return validCount;
        }

        static void Main(string[] args)
        {
            List<string> passSentences = new List<string>
        {
            "aa bb cc dd ee",
            "aa bb cc dd aa",
            "aa bb cc dd aaa"
        };
            int result = ValidatePassSentences(passSentences);
            Console.WriteLine(result); // Output: 2
        }
    }

}
