using System;

namespace RomanCalculatorTDD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************************************");
            Console.WriteLine("WELCOME TO THE ROMAN-ARABIC NUMBER CONVERTER");
            Console.WriteLine("********************************************");
            Console.WriteLine("Type exit to close the converter.");
            Console.WriteLine(string.Empty);

            while (true) // Loop indefinitely
            {
                Console.WriteLine("Enter roman number or arabic number to convert:");
                var line = Console.ReadLine() ?? string.Empty;
                line = line.ToUpper();

                if (line == "EXIT")
                {
                    break;
                }

                try
                {
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(string.Empty);
            }
        }
    }
}
