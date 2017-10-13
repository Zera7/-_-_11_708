using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            string[] date = new string[31];
            double[] amount = new double[31];

            int namesLength = names.Length;

            for (int i = 1; i <= 31; i++)
                date[i - 1] = i.ToString();

            for (int i = 0; i < namesLength; i++)
            {
                int day = names[i].BirthDate.Day;
                if (names[i].Name == name && day > 1 && day <= 31)
                    amount[day - 1]++;
            }

            return new HistogramData(string.Format("Рождаемость людей с именем '{0}'", name), date, amount);
        }
    }
}