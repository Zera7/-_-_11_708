using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var t in AlternateCharCases("cat")) Console.WriteLine(t);
            Console.Read();
        }


        //Вызывать будут этот метод
        public static List<string> AlternateCharCases(string lowercaseWord)
        {
            var result = new List<string>();
            AlternateCharCases(lowercaseWord.ToCharArray(), 0, result);
            return result;
        }

        static void AlternateCharCases(char[] word, int startIndex, List<string> result)
        {
            if (startIndex == word.Length)
            {
                result.Add(string.Concat(word));
                return;
            }
            if (char.IsNumber(word[startIndex]) ||
                char.ToUpper(word[startIndex]) == char.ToLower(word[startIndex]))
            {
                AlternateCharCases(word, startIndex + 1, result);
                return;
            }

            word[startIndex] = char.ToLower(word[startIndex]);
            AlternateCharCases(word, startIndex + 1, result);

            word[startIndex] = char.ToUpper(word[startIndex]);
            AlternateCharCases(word, startIndex + 1, result);
        }

    }
}
