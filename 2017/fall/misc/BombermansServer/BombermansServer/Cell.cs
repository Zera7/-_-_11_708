using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermansServer
{
    public class Cell : GameObject
    {
        public readonly Cells typeCell;
        private static Random rnd = new Random();

        public Cell(int health, int strength, Cells type) : base(health, strength)
        {
            this.typeCell = type;
        }

        public static Cell CreateCell(Cells type)
        {
            switch (type)
            {
                case Cells.Empty:
                case Cells.Spawn:
                case Cells.Fire:
                    return new Cell(1, byte.MaxValue, type);
                case Cells.Sand:
                case Cells.Bomb:
                    return new Cell(1, 1, type);
                case Cells.Rock:
                    return new Cell(1, 2, type);
                case Cells.Bonus:
                    return new Bonus(1, 0, (Bonuses)rnd.Next((int)Bonuses.last));
                default:
                    throw new Exception($"Тип ячейки '{type.ToString()}' не обработан");
            }
        }
    }
}
