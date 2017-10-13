using System;

namespace Names
{
	internal static class HeatmapTask
	{

		public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
		{
            string[] monthString = new string[12];
            string[] dayString = new string[30];

            double[,] amount = new double[30, 12];

            int namesLength = names.Length;

            for (int i = 2; i <= 31; i++)
                dayString[i-2] = i.ToString();

            for (int i = 1; i <= 12; i++)
                monthString[i - 1] = i.ToString();

            for (int i = 0; i < namesLength; i++) {
                int day = names[i].BirthDate.Day;
                int month = names[i].BirthDate.Month;
                if (day > 1 && day <= 31 && month > 0 && month <= 12)
                    amount[day - 2, month - 1]++;
            }


			return new HeatmapData("Пример карты интенсивностей", amount, dayString, monthString);
		}
	}
}