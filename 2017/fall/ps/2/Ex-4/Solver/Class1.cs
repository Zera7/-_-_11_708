using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public class LongArithmetic
    {
        // Возвращает большее число[0] и разницу между большим и меньшим[1]
        public static List<List<int>> Compare(List<int> bigA, List<int> bigB)
        {
            bigA.Reverse();
            bigB.Reverse();
            List<List<int>> sortedNumbers = SortLongNumbers(bigA, bigB);
            List<List<int>> result = new List<List<int>>
            {
                sortedNumbers[0],
                new List<int>(sortedNumbers[0]),
                sortedNumbers[2]
            };

            for (int i = 0; i < sortedNumbers[1].Count; i++)
            {
                if (result[1][i] - sortedNumbers[1][i] >= 0)
                    result[1][i] -= sortedNumbers[1][i];
                else
                {
                    result[1][i] -= -10 + sortedNumbers[1][i];
                    result[1][i + 1] -= 1;
                }
            }
            result[0].Reverse();
            result[1].Reverse();
            for (; result[1][0] == 0 && result[1].Count > 1;)
                result[1].RemoveAt(0);
            return result;
        }

        private static List<List<int>> SortLongNumbers(List<int> bigA, List<int> bigB)
        {
            List<List<int>> sortedNumbers = new List<List<int>>();
            if (bigA.Count > bigB.Count)
            {
                sortedNumbers.Add(bigA);
                sortedNumbers.Add(bigB);
                sortedNumbers.Add(new List<int> { 1 });
            }
            else if (bigA.Count < bigB.Count)
            {
                sortedNumbers.Add(bigB);
                sortedNumbers.Add(bigA);
                sortedNumbers.Add(new List<int> { -1 });
            }
            else
            {
                bool end = false;
                for (int i = bigA.Count - 1; i >= 0 && !end; i--)
                {
                    if (bigA[i] > bigB[i])
                    {
                        sortedNumbers.Add(bigA);
                        sortedNumbers.Add(bigB);
                        sortedNumbers.Add(new List<int> { 1 });
                        end = true;
                    }
                    else if (bigA[i] < bigB[i])
                    {
                        sortedNumbers.Add(bigB);
                        sortedNumbers.Add(bigA);
                        sortedNumbers.Add(new List<int> { -1 });
                        end = true;
                    }
                    else if (i == 0)
                    {
                        sortedNumbers.Add(bigA);
                        sortedNumbers.Add(bigB);
                        sortedNumbers.Add(new List<int> { 0 });
                    }
                }
            }
            return sortedNumbers;
        }

        private static List<int> GetDifference(List<int> bigA, List<int> bigB)
        {
            throw new NotImplementedException();
        }

        // Считает положительное целое число в n степени
        public static List<int> Pow(int number, int degree)
        {
            if (number < 0) number *= -1;
            List<int> reverseNumber = GetReverseNumber(number);
            List<int> bigNumber = new List<int>(reverseNumber);
            List<int> newBigNumber = new List<int>();
            if (degree == 0) { newBigNumber.Add(1); return newBigNumber; }
            for (int i = 1; i < degree; i++)
            {
                for (int q = 0; q < reverseNumber.Count; q++)
                {
                    for (int w = 0; w < bigNumber.Count; w++)
                    {
                        if (q + w >= newBigNumber.Count)
                            newBigNumber.Add(bigNumber[w] * reverseNumber[q]);
                        else
                            newBigNumber[q + w] += bigNumber[w] * reverseNumber[q];
                        //Перенос 
                        TransferDigit(newBigNumber, q + w);
                    }
                }
                bigNumber = new List<int>(newBigNumber);
                newBigNumber.Clear();
            }
            bigNumber.Reverse();
            return bigNumber;
        }

        private static void TransferDigit(List<int> newBigNumber, int i)
        {
            if (newBigNumber[i] / 10 != 0)
            {
                if (i + 1 >= newBigNumber.Count)
                    newBigNumber.Add(newBigNumber[i] / 10);
                else
                    newBigNumber[i + 1] += newBigNumber[i] / 10;
                newBigNumber[i] %= 10;
            }
        }

        private static List<int> GetReverseNumber(int number)
        {
            List<int> reverseNumber = new List<int>();
            while (number != 0)
            {
                reverseNumber.Add(number % 10);
                number /= 10;
            }
            return reverseNumber;
        }

        
    }
}
