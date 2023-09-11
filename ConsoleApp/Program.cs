using System;

class Program
{
    static double MF(double x)
    {
        return Math.Pow(x, 4) - 13 * Math.Pow(x, 2) + 36 - (1 / x);
    }

    static double BisectionMethod(double a, double b, out int count)
    {
        double an = a;
        double bn = b;
        count = 0;

        while ((bn - an) >= 2 * 0.000001)
        {
            double xn = (an + bn) / 2;

            if (MF(xn) == 0.0)
                return xn; // Ми знайшли корінь

            if (MF(an) * MF(xn) < 0)
                bn = xn; // Корінь знаходиться в лівому підвідрізку
            else
                an = xn; // Корінь знаходиться в правому підвідрізку

            count++;
        }
        
        // Повертаємо середнє значення знайденого відрізка
        return (an + bn) / 2;

        
    }   

    static double LinerMethod(double el1, double el2, out int count)
    {
        List<double> list = new List<double>();
        list.Add(el1);
        list.Add(el2);
        count = 0;
        do
        {
            double xn = list[list.Count - 1];
            double xn_ = list[list.Count - 2];
            double tmp = xn - ((xn_ - xn) / (MF(xn_) - MF(xn))) * MF(xn);
            list.Add(tmp);
            count++;            
        }
        while (Math.Round(Math.Abs(list.LastOrDefault() - list[list.Count - 2]), 5) > 0.000001);
       
        return list.LastOrDefault();

    }

    static void Main()
    {
        double a = 1, b = 2;
        int count;
        double root = LinerMethod(a, b, out count);

        Console.WriteLine("Liner Root = " + Math.Round(root, 5));
        Console.WriteLine("Liner Count = " + count + "\n");

        double result = BisectionMethod(a, b, out count);

        Console.WriteLine("Bisection Root: " + Math.Round(result, 5));
        Console.WriteLine("Bisection Count: " + count);
    }
}
