using System;
using System.Collections.Generic;
using RomanCalculatorTDD.Models;

namespace RomanCalculatorTDD
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = new List<RomanArabicValue>
            {
                new RomanArabicValue('I', 1, 3, true),
                new RomanArabicValue('V', 5 ,1, false),
                new RomanArabicValue('X', 10 ,3, true),
                new RomanArabicValue('L', 50 ,1, false),
                new RomanArabicValue('C', 100 ,3, true),
                new RomanArabicValue('D', 500 ,1, false),
                new RomanArabicValue('M', 1000, 3, true)
            };

            while (true) // Loop indefinitely
            {
                Console.WriteLine("Enter roman number or arabic number to convert:");
                string line = Console.ReadLine();
                if (line == "exit") 
                {
                    break;
                }

                var calculator = new RomanCalculator(values);
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
