using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.RationalNumbers
{
    public class Rational
    {
        public Rational(int numerator, int denominator = 1)
        {
            if (numerator < 0 == denominator < 0)
            {
                numerator = Math.Abs(numerator);
                denominator = Math.Abs(denominator);
            }
            else 
            {
                numerator = -Math.Abs(numerator);
                denominator = Math.Abs(denominator);
            }
            if (numerator != 0 && denominator != 0)
            {
                int gcd = GetGCD(numerator, denominator);
                numerator /= gcd;
                denominator /= gcd;
            }
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public int Numerator { get; set; }
        public int Denominator { get; set; }
        
        public bool IsNan { get => Denominator == 0; }

        public static Rational operator +(Rational a, Rational b)
        {
            if (a.IsNan || b.IsNan)
                return new Rational(0, 0);
            return new Rational(
                a.Numerator * b.Denominator + b.Numerator * a.Denominator, 
                a.Denominator * b.Denominator);
        }
        public static Rational operator -(Rational a, Rational b)
        {
            if (a.IsNan || b.IsNan)
                return new Rational(0, 0);
            return new Rational(
                            a.Numerator * b.Denominator - b.Numerator * a.Denominator,
                            a.Denominator * b.Denominator);
        }
        public static Rational operator *(Rational a, Rational b)
        {
            if (a.IsNan || b.IsNan)
                return new Rational(0, 0);
            return new Rational(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }
        public static Rational operator /(Rational a, Rational b)
        {
            if (a.IsNan || b.IsNan)
                return new Rational(0, 0);
            return new Rational(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static implicit operator double(Rational a) => (double)a.Numerator / a.Denominator;
        public static implicit operator Rational(int a) => new Rational(a);

        public static explicit operator int(Rational a)
        {
            if (a.Denominator == 0 || a.Numerator % a.Denominator != 0)
                throw new ArgumentException();
            else
                return a.Numerator / a.Denominator;
        }

        public override string ToString() => $"{Numerator} / {Denominator}";

        private int GetGCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
                b = a % (a = b);
            return a;
        }
    }
}
