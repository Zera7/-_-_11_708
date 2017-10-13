using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Names
{
    class HeatmapHome
    {
        public static HeatmapData GetHeatmapHome(NameData[] names, string name)
        {
            string[] monthString = new string[12];
            string[] dayString = new string[31];

            double[,] amount = new double[31,12];
            int[,] allNamesAmount = new int[31, 12];

            int namesLength = names.Length;

            for (int i = 1; i <= 12; i++)
                monthString[i - 1] = i.ToString();

            for (int i = 1; i <= 31; i++)
                dayString[i - 1] = i.ToString();

            for (int i = 0; i < namesLength; i++) {
                int month = names[i].BirthDate.Month;
                int day = names[i].BirthDate.Day;
                if (month > 0 && month <= 12 && day > 0 && day <= 31)
                {
                    if (names[i].Name == name)
                        amount[day - 1, month - 1]++;
                    allNamesAmount[day - 1, month - 1]++;
                }
            }

            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                {
                    if (allNamesAmount[j,i] != 0)
                    amount[j, i] = (int)(amount[j, i] / allNamesAmount[j, i] * 1000000);
                }
            

            return new HeatmapData(string.Format("Рождаемость людей с именем '{0}'", name), amount, dayString, monthString);
        }
    }
}

