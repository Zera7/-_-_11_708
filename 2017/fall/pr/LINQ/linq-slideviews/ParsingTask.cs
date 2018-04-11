using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_slideviews
{
	public class ParsingTask
	{
		/// <param name="lines">все строки файла, которые нужно распарсить. Первая строка заголовочная.</param>
		/// <returns>Словарь: ключ — идентификатор слайда, значение — информация о слайде</returns>
		/// <remarks>Метод должен пропускать некорректные строки, игнорируя их</remarks>
		public static IDictionary<int, SlideRecord> ParseSlideRecords(IEnumerable<string> lines)
		{
            return lines
                .Select(a => a.Split(';'))
                .Where(a => a.Length == 3 && 
                int.TryParse(a[0], out int n) &&
                GetTypeString(a[1]) != -1)
                .GroupBy(a => a[0])
                .ToDictionary(a => int.Parse(a.Key), a =>
                {
                    var b = a.ToArray();
                    return new SlideRecord(int.Parse(b[0][0]), (SlideType)GetTypeString(b[0][1]), b[0][2]);
                });
        }

        private static int GetTypeString(string v)
        {
            if (v == "theory") return 0;
            if (v == "exercise") return 1;
            if (v == "quiz") return 2;
            else return -1;
        }

        /// <param name="lines">все строки файла, которые нужно распарсить. Первая строка — заголовочная.</param>
        /// <param name="slides">Словарь информации о слайдах по идентификатору слайда. 
        /// Такой словарь можно получить методом ParseSlideRecords</param>
        /// <returns>Список информации о посещениях</returns>
        /// <exception cref="FormatException">Если среди строк есть некорректные</exception>
        public static IEnumerable<VisitRecord> ParseVisitRecords(
			IEnumerable<string> lines, IDictionary<int, SlideRecord> slides)
		{
            string[] arr;
            int n = 0;

            return lines
                .Skip(1)
                .Select(a =>
                {
                    arr = a.Split(';');
                    if (arr.Length != 4 ||
                        !int.TryParse(arr[0], out n) ||
                        !int.TryParse(arr[1], out n) ||
                        !DateTime.TryParse(arr[2], out DateTime m) ||
                        !DateTime.TryParse(arr[3], out m) ||
                        !slides.ContainsKey(n))
                        throw new FormatException("Wrong line [" + a + "]");
                    return new VisitRecord(
                        int.Parse(arr[0]),
                        int.Parse(arr[1]),
                        DateTime.Parse(arr[2] + ' ' + arr[3]),
                        slides[int.Parse(arr[1])].SlideType);
                })
                .ToArray();
        }
	}
}