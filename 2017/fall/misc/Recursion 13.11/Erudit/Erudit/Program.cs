using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Александр Скворцов

    4.Эрудит
*/

namespace Erudit
{
    class Program
    {
        static void Main(string[] args)
        {
            //Начало цикла
            string end = "";
            do
            {
                Console.WriteLine("START");

                List<string> words = GetWords();

                //Вывод результата и конец цикла
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }

        private static List<string> GetWords()
        {
            List<string> words = new List<string>();
            string word = "";
            do
            {
                word = Console.ReadLine();
                if (word != "") words.Add(word);
                else return words;
            } while (true);
        }

        static string[] GetInput()
        {
            Console.WriteLine("Enter the field: ");
            string word = Console.ReadLine();
            string[] field = new string[word.Length];
            for (int i = 0; i < field[0].Length - 1; i++)
            {

            }
        
            return numbers;
        }

        
    }
}
