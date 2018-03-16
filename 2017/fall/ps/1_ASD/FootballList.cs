using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ASD_1
{
    public class FootballList : IEnumerable
    {
        FootballClub[] Clubs = new FootballClub[32];
        FootballClub[] bufferArray;
        public int Count { get; private set; } = 0;
        private bool isLexicographicalSorted = true;

        public FootballList() { }
        public FootballList(params FootballClub[] a)
        {
            Count = a.Length;
            for (int i = 0; i < Count; i++)
                Clubs[i] = a[i];
        }

        public FootballClub this[int index]
        {
            get { Check(index); return Clubs[index]; }
            set { Check(index); Clubs[index] = value; }
        }

        /// <summary>
        /// Получает данные о клубах
        /// </summary>
        /// <param name="path">Путь к файлу с данными</param>
        public void ReadClubs(string path)
        {
            string[][] infoClubs = GetClubsInfo(path);
            Clubs = new FootballClub[infoClubs.Length];
            Count = infoClubs.Length;
            for (int i = 0; i < infoClubs.Length; i++)
                Clubs[i] = GetClubFromString(infoClubs[i]);
        }
        
        /// <summary>
        /// Получает данные клубов по последнему туру и добавляет их
        /// </summary>
        /// <param name="path">Путь к файлу, содержащему данные нового тура</param>
        public void UpdateClubs(string path)
        {
            string[][] infoClubs = GetClubsInfo(path);
            FootballClub a;
            int indexNewClubs = 0;
            int index = 0;
            int compare = 0;

            if (!isLexicographicalSorted) Sort(LexicographicalCompare);

            while (indexNewClubs < infoClubs.Length && index < Count)
            {
                a = GetClubFromString(infoClubs[indexNewClubs]);
                compare = LexicographicalCompare(a, Clubs[index]);

                // Обновление для клуба и клуб совпали
                if (compare == 0)
                {
                    IncraseClubResults(Clubs[index], a);
                    index++;
                    indexNewClubs++;
                }
                // Клуб лексикографически раньше чем текущий
                else if (compare < 0) throw new Exception();
                // Клуб лексикографически позже чем текущий
                else index++;
            }
        }

        /// <summary>
        /// Сортирует клубы по названиям в лексикографическом порядке
        /// </summary>
        public void Sort()
        {
            Sort(LexicographicalCompare);
        }

        /// <summary>
        /// Сортирует клубы по переданному компаратору
        /// </summary>
        /// <param name="comparer">Определяет как будут сравниваться элементы</param>
        public void Sort(Func<FootballClub, FootballClub, int> comparer)
        {
            BubbleSort(comparer, this);
            isLexicographicalSorted = false;
        }

        public FootballClub GetMinDrawsClub()
        {
            FootballClub minDrawsClub = Clubs[0];
            for (int i = 1; i < Count; i++)
                if (minDrawsClub.Draws > Clubs[i].Draws) minDrawsClub = Clubs[i];
            return minDrawsClub;
        }

        public FootballClub GetMaxDifferenceScoredAndConcededClub()
        {
            FootballClub maxDifferenceClub = Clubs[0];
            for (int i = 1; i < Count; i++)
                if (maxDifferenceClub.GoalsScored - maxDifferenceClub.GoalsConceded < 
                    Clubs[i].GoalsScored - Clubs[i].GoalsConceded)
                    maxDifferenceClub = Clubs[i];
            return maxDifferenceClub;
        }

        private void BubbleSort(Func<FootballClub, FootballClub, int> comparer, FootballList list)
        {
            for (int i = 0; i < list.Count - 1; i++)
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (comparer(list.Clubs[j], list.Clubs[j + 1]) > 0)
                    {
                        var a = list.Clubs[j];
                        list.Clubs[j] = list.Clubs[j + 1];
                        list.Clubs[j + 1] = a;
                    }
                }
        }

        public FootballList GetSortedFootballList(Func<FootballClub, FootballClub, int> comparer)
        {
            FootballList a = new FootballList
            {
                Clubs = new FootballClub[Clubs.Length]
            };
            for (int i = 0; i < Count; i++)
                a.Clubs[i] = new FootballClub(Clubs[i]);
            a.Count = Count;
            BubbleSort(comparer, a);
            return a;
        }

        private static int LexicographicalCompare(FootballClub a, FootballClub b)
        {
            return string.Compare(a.Name, b.Name);
        }

        private void IncraseClubResults(FootballClub a, FootballClub b)
        {
            a.Wins += b.Wins;
            a.Draws += b.Draws;
            a.Losses += b.Losses;
            a.GoalsScored += b.GoalsScored;
            a.GoalsConceded += b.GoalsConceded;
        }

        private string[][] GetClubsInfo(string path)
        {
            string[] buffer = File.ReadAllLines(path);
            string[][] clubsInfo = new string[buffer.Length][];

            for (int i = 0; i < buffer.Length; i++)
                clubsInfo[i] = buffer[i].Split(' ');

            return clubsInfo;
        }

        private FootballClub GetClubFromString(string[] clubInfo)
        {
            return new FootballClub(
                clubInfo[0],
                    int.Parse(clubInfo[1]),
                    int.Parse(clubInfo[2]),
                    int.Parse(clubInfo[3]),
                    int.Parse(clubInfo[4]),
                    int.Parse(clubInfo[5])
                );
        }

        private void Check(int index)
        {
            if (index < 0 || index >= Clubs.Length) throw new IndexOutOfRangeException();
        }

        private void ArrayExpand()
        {
            bufferArray = Clubs;
            Clubs = new FootballClub[Clubs.Length * 2];
            for (int i = 0; i < bufferArray.Length; i++)
                Clubs[i] = bufferArray[i];
            bufferArray = null;
        }

        public IEnumerator GetEnumerator()
        {
            int i = 0;
            while (i < Count)
                yield return Clubs[i++];
        }
    }
}