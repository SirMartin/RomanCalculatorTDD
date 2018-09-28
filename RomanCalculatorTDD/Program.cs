using System;

namespace RomanCalculatorTDD
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) // Loop indefinitely
            {
                Console.WriteLine("Enter roman number or arabic number to convert:");
                string line = Console.ReadLine();
                if (line == "exit") 
                {
                    break;
                }

                var calculator = new RomanCalculator();
                if (int.TryParse(line, out int arabic))
                {
                    Console.WriteLine($"{line} in roman numbers is {calculator.ToRomanNumber(arabic)}");
                }
                else
                {
                    Console.WriteLine($"{line} in arabic numbers is {calculator.ToArabicNumber(line)}");
                }
            }
        }
    }
}
