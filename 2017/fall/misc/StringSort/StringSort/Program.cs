using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSort
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = { "das", "as", "w", "a", "zxc", "dfsgsf" };
            // ref использовать не хорошо
            // но иногда можно
            StringSort(ref a, 32, 'a');
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }

        public static string[] StringSort(ref string[] arr, int cardinality, char firstLetter)
        {
            StringLengthSort(arr);
            int maxIndex = arr[arr.Length - 1].Length - 1;
            int difference = 0;
            int counter = 0;

            Stack<string>[] buffer = new Stack<string>[cardinality + 1];
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = new Stack<string>();
            List<string> result = arr.Cast<string>().ToList();

            while (maxIndex >= 0)
            {
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (result[i].Length < maxIndex + 1)
                    {
                        maxIndex = result[i].Length - 1;
                        break;
                    }

                    difference = result[i][maxIndex] - firstLetter;
                    if (difference >= cardinality)
                        buffer[cardinality - 1].Push(result[i]);
                    else
                        buffer[difference].Push(result[i]);
                    counter++;
                    if (i == 0) maxIndex--;
                }
                result.RemoveRange(arr.Length - counter, counter);
                counter = 0;
                for (int j = 0; j < buffer.Length; j++)
                    if (buffer[j].Count > 0)
                    {
                        result.AddRange(buffer[j]);
                        buffer[j].Clear();
                    }
            }
            return arr = result.ToArray();
        }

        // Функция сортировки массива слов по их длине
        private static void StringLengthSort(string[] arr)
        {
            string buffer;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                    if (arr[j].Length > arr[j + 1].Length)
                    {
                        buffer = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = buffer;
                    }
            }
        }
    }
}
