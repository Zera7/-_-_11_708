using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermansServer
{
    public class Bonus : Cell
    {
        public readonly Bonuses bonusType;
        public Bonus(int health, int strength, Bonuses bonusType) : base(health, strength, Cells.Bonus)
        {
            this.bonusType = bonusType;
        }
    }
}
