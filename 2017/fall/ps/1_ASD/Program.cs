using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            FootballList list = new FootballList();

            Console.WriteLine("Тест получения списка команд");
            list.ReadClubs("FirstTour.txt");
            foreach (var item in list) Console.WriteLine(item + "\n");
            Console.WriteLine("\n----------\n");

            Console.WriteLine("Тест обновления списка команд");
            list.UpdateClubs("UpdateClubs.txt");
            foreach (var item in list) Console.WriteLine(item + "\n");
            Console.WriteLine("\n----------\n");

            Console.WriteLine("Тест сортировки по числу набранных очков");
            list.Sort(CompareByScore);
            foreach (var item in list) Console.WriteLine(item + "\n");
            Console.WriteLine("\n----------\n");

            Console.WriteLine("Тест формирования нового списка, отсортированного по числу забитых мячей");
            FootballList newList = list.GetSortedFootballList(CompareByGoalsScored);
            foreach (var item in newList) Console.WriteLine(item + "\n");
            Console.WriteLine("\n----------\n");

            Console.WriteLine("Тест нахождения клуба с наименьшим количеством ничьих");
            Console.WriteLine("Минимум ничьих:\n"+list.GetMinDrawsClub());
            Console.WriteLine("\n----------\n");

            Console.WriteLine("Тест нахождения клуба с максимальной разницей между забитыми и пропущенными голами");
            Console.WriteLine("Максимальная разница забитых и пропущенных:\n"+list.GetMaxDifferenceScoredAndConcededClub());
            Console.WriteLine("\n----------\n");

            Console.Read();
        }

        /// <summary>
        /// Сравнивает 2 клуба по количеству очков
        /// </summary>
        /// <param name="a">Первый клуб</param>
        /// <param name="b">Второй клуб</param>
        /// <returns>
        /// Возвращает 1, если у первого клуба очков больше;
        /// Возвращает -1, если у первого клуба очков меньше;
        /// Возвращает 0, если количество очков у клубов одинаково
        /// </returns>
        public static int CompareByScore(FootballClub a, FootballClub b)
        {
            int aScore = a.Wins * 3 - a.Draws;
            int bScore = b.Wins * 3 - b.Draws;
            if (aScore > bScore) return 1;
            else if (aScore == bScore) return 0;
            else return -1;
        }

        /// <summary>
        /// Сравнивает 2 клуба по количеству забитых голов
        /// </summary>
        /// <param name="a">Первый клуб</param>
        /// <param name="b">Второй клуб</param>
        /// <returns>
        /// Возвращает 1, если у первого клуба очков больше;
        /// Возвращает -1, если у первого клуба очков меньше;
        /// Возвращает 0, если количество очков у клубов одинаково</returns>
        public static int CompareByGoalsScored(FootballClub a, FootballClub b)
        {
            if (a.GoalsScored > b.GoalsScored) return 1;
            else if (a.GoalsScored == b.GoalsScored) return 0;
            else return -1;
        }
    }
}