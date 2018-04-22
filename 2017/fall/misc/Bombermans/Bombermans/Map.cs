using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombermans
{
    static class Map
    {
        public static int FieldWidth { get; private set; }
        public static GameObject[,] Field { get; set; }

        public static bool DownloadMap(string fileName)
        {
            if (File.Exists(fileName))
            {
                // Дописать
                string[] field = File.ReadAllLines(fileName);
                FieldWidth = field[0].Length;
                Field = new GameObject[FieldWidth, FieldWidth];
                for (int i = 0; i < FieldWidth; i++)
                    for (int j = 0; j < FieldWidth; j++)
                    {
                        Field[i,j] = AddObject(field, i, j);
                    }
                return true;
            }
            else
                return false;
        }

        private static GameObject AddObject(string[] a, int i, int j)
        {
            switch (a[i][j])
            {
                case '0':
                    return null;
                case (char)StaticObjectType.Bonus:
                    return new Bonus(new Coords(i, j));
                case (char)StaticObjectType.Fire:
                    return null;
                case (char)StaticObjectType.Player:
                    // Дописать
                    return null;
                case (char)StaticObjectType.Sand:
                    return new Sand(new Coords(i, j));
                case (char)StaticObjectType.Wall:
                    return new Wall(new Coords(i, j));
                default:
                    return null;
            }
        }
    }
}
