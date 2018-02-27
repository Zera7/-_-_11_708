using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombermans
{
    class Player : GameObject
    {
        public Player(Coords coords) : base(coords)
        {
        }

        public int MaximumSkillValue { get; private set; } = 10;

        private int speed = 1;
        private int maxAmountBombs = 1;
        private int powerBombs = 1;

        public int Speed { get { return speed; } set => ChangeSkill(ref speed); }
        public int MaxAmountBombs { get { return maxAmountBombs; } set => ChangeSkill(ref maxAmountBombs); }
        public int PowerBombs { get { return powerBombs; } set => ChangeSkill(ref powerBombs); }

        private void ChangeSkill(ref int skill)
        {
            if (skill < MaximumSkillValue)
                skill++;
        }

        private void Move(Coords newCoords)
        {
            var a = Map.Field[newCoords.X, newCoords.Y];
            if (a == null || a.GetType().Name == ObjectType.Bonus.ToString())
            Coords = newCoords;
        }

        public override void Die()
        {
            throw new NotImplementedException();
        }

        public override void Intersect(GameObject obj)
        {
            throw new NotImplementedException();
        }
    }
}
