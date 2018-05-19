using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermansServer
{
    public class Map
    {
        public Cell[,] Field { get; set; }
        public List<Coords2D> Spawners = new List<Coords2D>();

        public void DownloadMap(string path)
        {
            if (!File.Exists(path))
                throw new Exception("Map doesn't exist");
            string[] TextMap = File.ReadAllLines(path);

            Field = new Cell[TextMap[0].Length, TextMap[0].Length];

            for (int i = 0; i < TextMap[0].Length; i++)
                for (int j = 0; j < TextMap[0].Length; j++)
                    Field[i, j] = GetCellByChar(TextMap[i][j], j, i);
        }

        public Map CloneMap()
        {
            Map newMap = new Map
            {
                Spawners = this.Spawners
            };
            Array.Copy(Field, newMap.Field, Field.Length);
            return newMap;
        }

        private Cell GetCellByChar(char a, int x, int y)
        {
            if ((Cells)a == Cells.Spawn) Spawners.Add(new Coords2D(x, y));
            return Cell.CreateCell((Cells)a);
        }
    }
}