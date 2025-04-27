namespace Test3
{
    using System;

    class Program
    {
        static void Main()
        {
            int[] arr1 = { 1, 4, 3, 6, 7, 0 };
            int[] arr2 = { -1, -3, -4, 2, 0, -5 };

            var result1 = FindMaxProductPair(arr1);
            Console.WriteLine($"[{result1.Item1}, {result1.Item2}]");

            var result2 = FindMaxProductPair(arr2);
            Console.WriteLine($"[{result2.Item1}, {result2.Item2}]");
        }

        static (int, int) FindMaxProductPair(int[] arr)
        {
            if (arr.Length < 2)
                throw new ArgumentException("Array must have at least two elements");

            int max1 = int.MinValue, max2 = int.MinValue;
            int min1 = int.MaxValue, min2 = int.MaxValue;

            foreach (int num in arr)
            {
                if (num > max1)
                {
                    max2 = max1;
                    max1 = num;
                }
                else if (num > max2)
                {
                    max2 = num;
                }

                if (num < min1)
                {
                    min2 = min1;
                    min1 = num;
                }
                else if (num < min2)
                {
                    min2 = num;
                }
            }

            int product1 = max1 * max2;
            int product2 = min1 * min2;

            return (product1 > product2) ? (max1, max2) : (min1, min2);
        }
    }
}

