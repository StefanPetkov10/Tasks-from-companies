namespace Tests
{
    class Program
    {
        static void Main()
        {
            string order = "milkshakepizzachickenfriescokeburgerpizzasandwichmilkshakepizza";
            string formattedOrder = FormatOrder(order);
            Console.WriteLine(formattedOrder);
        }

        static string FormatOrder(string order)
        {
            List<string> menu = new List<string> { "Pizza", "Sandwich", "Burger", "Fries", "Chicken", "Onionrings", "Milkshake", "Coke" };
            List<string> result = new List<string>();

            int i = 0;
            while (i < order.Length)
            {
                foreach (var item in menu)
                {
                    if (order.Substring(i).StartsWith(item.ToLower()))
                    {
                        result.Add(item);
                        i += item.Length;
                        break;
                    }
                }
            }

            return string.Join(" ", result);
        }
    }
}
