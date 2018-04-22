using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombermans
{
    enum TypeBonus
    {
        SpeedUp,
        PowerUp,
        BombUp
    }

    class Bonus : GameObject
    {
        public TypeBonus Type { get; }

        public Bonus(Coords coords) : base(coords)
        {
            Random random = new Random();
            Type = (TypeBonus)random.Next(3);
        }

        public override void Die()
        {
            
        }

        public override void Intersect(GameObject obj)
        {
            if (obj.GetType().Name == StaticObjectType.Player.ToString())
            {

            }
        }
    }
}
