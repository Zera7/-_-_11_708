using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombermans
{
    public enum StaticObjectType
    {
        Wall,
        Sand,
    }

    public enum DynamicObjectType
    {
        Player,
        Bonus,
        Fire,
    }

    abstract class GameObject
    {
        public GameObject(Coords coords)
        {
            if (coords.X < 0 || coords.X >= Map.FieldWidth ||
                coords.Y < 0 || coords.Y >= Map.FieldWidth)
                throw new Exception("Неверные координаты инициализации объекта");
            this.Coords = coords;
        }

        public Coords Coords { get; set; }

        abstract public void Die();
        abstract public void Draw();
        abstract public void Intersect(GameObject obj);
    }
}