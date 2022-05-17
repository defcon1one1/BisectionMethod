using System;

namespace Bisection
{
    internal class Program
    {

        static void Main()
        {
            Console.WriteLine("Enter a:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter b:");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter c:");
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter d:");
            double d = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter e:");
            double e = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter g:");
            double g = double.Parse(Console.ReadLine());

            double epsilon = 0.000001;
            double step = 0.0001;
            double min = -100;
            double max = 100;
            double left = 0;
            double right = 0;
            double mid = 0;

            double f(double x)
            {
                return a * Math.Pow(x, 5) + b * Math.Pow(x, 4) + c * Math.Pow(x, 3) + d * Math.Pow(x, 2) + e * x + g;
            }

            Console.WriteLine($"\nPolynomial:\n{a}x^5 + {b}x^4 + {c}x^3 + {d}x^2 + {e}x + {g} = 0");
            Console.WriteLine($"\nRoots:");

            for (double x = min; x <= max; x = Math.Round((x + step), 5))
            {
                if (f(x) == 0) // checks for "round" solution and prints it in the console
                {
                    Console.WriteLine($"x: {x}");
                    //continue;
                }
                
                if (f(x) * f(x + step) < 0) // potential scope for a root
                {
                    left = x; 
                    right = Math.Round((x + step), 15);
                    mid = Math.Round(((x + x + step) / 2.0), 15); 
                    do // bisection
                    {
                        if (f(left) * f(mid) < 0) // if the solution is on the left, right becomes new mid
                        {
                            right = mid;
                            mid = Math.Round(((left + right) /2.0), 15);
                        }
                        else if (f(right) * f(mid) < 0) // if the solution is on the right, mid becomes new left
                        {
                            left = mid;
                            mid = Math.Round(((left + right)/2.0), 15);
                        }
                    } while (Math.Abs(f(left) - f(right)) < epsilon); // repeat until the point of precision epsilon
                    Console.WriteLine($"x:{Math.Round((mid), 6)}"); // print the outcome
                }
            }
        }
    }
}