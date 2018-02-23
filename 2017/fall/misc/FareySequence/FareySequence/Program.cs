using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Вычисление ряда Фарея
*/

namespace FareySequence
{
    class Program
    {
        struct Fraction
        {
            public int Numerator { get; set; }
            public int Denominator { get; set; }

            public Fraction(int numerator, int denominator)
            {
                this.Numerator = numerator;
                this.Denominator = denominator;
            }

            // Override ToString function
            public override string ToString()
            {
                return Numerator.ToString() + " / " + Denominator.ToString();
            }

            // Overload of the addition operator for fractions
            public static Fraction operator +(Fraction a, Fraction b)
            {
                return new Fraction(a.Numerator + b.Numerator, a.Denominator + b.Denominator);
            }
        }

        static void Main(string[] args)
        {
            // The first and last element of the sequence
            List<Fraction> fractions = new List<Fraction>
            {
                new Fraction(0, 1),
                new Fraction(1, 1)
            };

            // Maximum denominator input
            int maxDenominator = 1;
            while (!int.TryParse(Console.ReadLine(), out maxDenominator)) ;

            // Computation of a sequence
            int i;
            Fraction newFraction;
            do
            {
                i = 0;
                for (int j = fractions.Count - 2; j >= 0 ; j--)
                {
                    newFraction = fractions[j] + fractions[j + 1];
                    if (newFraction.Denominator <= maxDenominator)
                    {
                        fractions.Insert(j + 1, newFraction);
                        i++;
                    }
                }
            } while (i != 0);

            ////////////////////////
            // Test
            foreach (var item in fractions)
                Console.WriteLine(item);
            Console.Read();
            ////////////////////////
        }
    }
}
// Need more comments
