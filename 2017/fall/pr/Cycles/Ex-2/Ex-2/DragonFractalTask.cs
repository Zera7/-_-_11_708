// В этом пространстве имен содержатся средства для работы с изображениями. Чтобы оно стало доступно, в проект был подключен Reference на сборку System.Drawing.dll
using System.Drawing;
using System;

namespace Fractals
{
	internal static class DragonFractalTask
	{
		public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
		{
            double angle45 = Math.PI * 45 / 180;
            double angle135 = Math.PI * 135 / 180;
            double x = 1, y = 0, x1 = 0, y1 = 0;
            Random random = new Random(seed);

            for (int i = 0; i < iterationsCount; i++) {
                if (random.Next(2) == 0)
                {
                    x1 = ((x * Math.Cos(angle45) - y * Math.Sin(angle45)) / Math.Sqrt(2));
                    y1 = ((x * Math.Sin(angle45) + y * Math.Cos(angle45)) / Math.Sqrt(2));
                }
                else
                {
                    x1 = (x * Math.Cos(angle135) - y * Math.Sin(angle135)) / Math.Sqrt(2) + 1;
                    y1 = (x * Math.Sin(angle135) + y * Math.Cos(angle135)) / Math.Sqrt(2);
                }
                x = x1;
                y = y1;
                pixels.SetPixel(x, y);
            }
		}
	}
}