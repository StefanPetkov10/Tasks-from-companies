namespace Tests
{
    class Result
    {
        public static void price()
        {
            try
            {
                string[] inputLines = new string[6];
                for (int i = 0; i < 6; i++)
                {
                    inputLines[i] = Console.ReadLine()?.Trim();
                }

                if (!double.TryParse(inputLines[0], out double yearsToMaturity) ||
                    !decimal.TryParse(inputLines[1], out decimal faceValue) ||
                    yearsToMaturity <= 0 || faceValue <= 0)
                {
                    Console.WriteLine("Invalid Maturity / Face Value");
                    return;
                }

                var couponTimes = inputLines[2].Split(',').Select(x => x.Trim());
                var couponAmounts = inputLines[3].Split(',').Select(x => x.Trim());

                if (couponTimes.Count() != couponAmounts.Count())
                {
                    Console.WriteLine("Invalid Coupon Schedule");
                    return;
                }

                var coupons = new List<(double years, decimal amount)>();
                for (int i = 0; i < couponTimes.Count(); i++)
                {
                    if (!double.TryParse(couponTimes.ElementAt(i), out double couponTime) ||
                        !decimal.TryParse(couponAmounts.ElementAt(i), out decimal couponAmount) ||
                        couponTime < 0 || couponTime > yearsToMaturity)
                    {
                        Console.WriteLine("Invalid Coupon Schedule");
                        return;
                    }
                    coupons.Add((couponTime, couponAmount));
                }

                var discountTimes = inputLines[4].Split(',').Select(x => x.Trim());
                var discountFactors = inputLines[5].Split(',').Select(x => x.Trim());

                if (discountTimes.Count() != discountFactors.Count())
                {
                    Console.WriteLine("Invalid Discount Curve");
                    return;
                }

                var discountCurve = new List<(double years, decimal factor)>();
                for (int i = 0; i < discountTimes.Count(); i++)
                {
                    if (!double.TryParse(discountTimes.ElementAt(i), out double discountTime) ||
                        !decimal.TryParse(discountFactors.ElementAt(i), out decimal discountFactor) ||
                        discountTime < 0 || discountFactor <= 0)
                    {
                        Console.WriteLine("Invalid Discount Curve");
                        return;
                    }
                    discountCurve.Add((discountTime, discountFactor));
                }

                if (discountCurve.Count == 0 || discountCurve[0].years != 0 || discountCurve[0].factor != 1m)
                {
                    Console.WriteLine("Invalid Discount Curve");
                    return;
                }

                decimal bondPV = CalculateBondPV(yearsToMaturity, faceValue, coupons, discountCurve);
                Console.WriteLine($"{bondPV:F2}");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Input Format");
            }
        }

        private static decimal CalculateBondPV(double yearsToMaturity, decimal faceValue,
            List<(double years, decimal amount)> coupons,
            List<(double years, decimal factor)> discountCurve)
        {
            decimal pv = 0;

            foreach (var coupon in coupons)
            {
                decimal discountFactor = GetDiscountFactor(coupon.years, discountCurve);
                pv += coupon.amount * discountFactor;
            }

            decimal maturityDiscountFactor = GetDiscountFactor(yearsToMaturity, discountCurve);
            pv += faceValue * maturityDiscountFactor;

            return pv;
        }

        private static decimal GetDiscountFactor(double years, List<(double years, decimal factor)> discountCurve)
        {
            var applicablePoint = discountCurve
                .Where(x => x.years <= years)
                .OrderByDescending(x => x.years)
                .FirstOrDefault();

            return applicablePoint.factor;
        }
    }

    class Programm
    {
        public static void Main(string[] args)
        {
            Result.price();
        }
    }
}

//For Test Output
/*class BondPricing
{
    static void Main()
    {
        try
        {
            double yearsToMaturity = 5;
            decimal faceValue = 10000m;

            var coupons = new List<(double years, decimal amount)>
            {
                (0.5, 250m),
                (1, 250m),
                (1.5, 250m),
                (2, 250m),
                (2.5, 250m),
                (3, 250m),
                (3.5, 250m),
                (4, 250m),
                (4.5, 250m),
                (5, 250m)
            };

            var discountCurve = new List<(double years, decimal factor)>
            {
                (0, 1m),
                (1, 0.95m),
                (2, 0.91m),
                (3, 0.87m),
                (4, 0.83m),
                (5, 0.8m)
            };

            decimal bondPV = CalculateBondPV(yearsToMaturity, faceValue, coupons, discountCurve);
            Console.WriteLine($"The present value of the bond is: {bondPV:F2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static decimal CalculateBondPV(double yearsToMaturity, decimal faceValue,
        List<(double years, decimal amount)> coupons,
        List<(double years, decimal factor)> discountCurve)
    {
        decimal pv = 0;

        foreach (var coupon in coupons)
        {
            decimal discountFactor = GetDiscountFactor(coupon.years, discountCurve);
            pv += coupon.amount * discountFactor;
        }

        decimal maturityDiscountFactor = GetDiscountFactor(yearsToMaturity, discountCurve);
        pv += faceValue * maturityDiscountFactor;

        return pv;
    }

    private static decimal GetDiscountFactor(double years, List<(double years, decimal factor)> discountCurve)
    {
        // Find the greatest time in discount curve that is <= years
        var applicablePoint = discountCurve
            .Where(x => x.years <= years)
            .OrderByDescending(x => x.years)
            .FirstOrDefault();

        return applicablePoint.factor;
    }
}*/

class Result
{
    public static void price()
    {
        string[] inputLines = new string[6];
        for (int i = 0; i < 6; i++)
        {
            inputLines[i] = Console.ReadLine()?.Trim();
        }

        if (!double.TryParse(inputLines[0], out double yearsToMaturity) ||
            !decimal.TryParse(inputLines[1], out decimal faceValue) ||
            yearsToMaturity <= 0 || faceValue <= 0)
        {
            Console.WriteLine("Invalid Maturity / Face Value");
            return;
        }

        for (int i = 0; i < 6; i++)
        {
            if (string.IsNullOrEmpty(inputLines[i]))
            {
                Console.WriteLine("Invalid Input Format");
                return;
            }
        }

        var couponTimes = inputLines[2].Split(',').Select(x => x.Trim());
        var couponAmounts = inputLines[3].Split(',').Select(x => x.Trim());

        if (couponTimes.Count() != couponAmounts.Count())
        {
            Console.WriteLine("Invalid Coupon Schedule");
            return;
        }

        var coupons = new List<(double years, decimal amount)>();
        for (int i = 0; i < couponTimes.Count(); i++)
        {
            if (!double.TryParse(couponTimes.ElementAt(i), out double couponTime) ||
                !decimal.TryParse(couponAmounts.ElementAt(i), out decimal couponAmount) ||
                couponTime < 0 || couponTime > yearsToMaturity)
            {
                Console.WriteLine("Invalid Coupon Schedule");
                return;
            }
            coupons.Add((couponTime, couponAmount));
        }

        var discountTimes = inputLines[4].Split(',').Select(x => x.Trim());
        var discountFactors = inputLines[5].Split(',').Select(x => x.Trim());

        if (discountTimes.Count() != discountFactors.Count())
        {
            Console.WriteLine("Invalid Discount Curve");
            return;
        }

        var discountCurve = new List<(double years, decimal factor)>();
        for (int i = 0; i < discountTimes.Count(); i++)
        {
            if (!double.TryParse(discountTimes.ElementAt(i), out double discountTime) ||
                !decimal.TryParse(discountFactors.ElementAt(i), out decimal discountFactor) ||
                discountTime < 0 || discountFactor <= 0)
            {
                Console.WriteLine("Invalid Discount Curve");
                return;
            }
            discountCurve.Add((discountTime, discountFactor));
        }

        if (discountCurve.Count == 0 || discountCurve[0].years != 0 || discountCurve[0].factor != 1m)
        {
            Console.WriteLine("Invalid Discount Curve");
            return;
        }

        decimal bondPV = 0;

        foreach (var coupon in coupons)
        {
            var applicablePoint = discountCurve
                .Where(x => x.years <= coupon.years)
                .OrderByDescending(x => x.years)
                .FirstOrDefault();

            bondPV += coupon.amount * applicablePoint.factor;
        }

        var maturityPoint = discountCurve
            .Where(x => x.years <= yearsToMaturity)
            .OrderByDescending(x => x.years)
            .FirstOrDefault();

        bondPV += faceValue * maturityPoint.factor;

        Console.WriteLine($"{bondPV:F2}");
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        Result.price();
    }
}