namespace Test2
{
    class Program
    {
        static void Main()
        {
            int[] array = { 7, 4, 7, 7, 7, 7, 5, 7 };
            Dictionary<int, int> elements = new();

            for (int i = 0; i < array.Length; i++)
            {
                if (elements.ContainsKey(array[i]))
                {
                    elements[array[i]]++;
                }
                else
                {
                    elements[array[i]] = 1;
                }
            }

            int maxElementCount = -1;
            foreach (var maxElementDict in elements)
            {
                if (maxElementDict.Value > maxElementCount)
                {
                    maxElementCount = maxElementDict.Value;
                }
            }

            foreach (var result in elements)
            {
                if (result.Value == maxElementCount)
                {
                    Console.WriteLine(result.Key);
                }
            }
        }
    }
}
