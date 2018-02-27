using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombermans
{
    class Wall : GameObject
    {
        public Wall(Coords coords) : base(coords)
        {

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
