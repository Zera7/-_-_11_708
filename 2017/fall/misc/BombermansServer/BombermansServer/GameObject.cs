using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermansServer
{
    public class GameObject
    {
        public int HealthPoints { get; set; }
        public int Strength { get; set; }

        public GameObject(int health, int strength)
        {
            this.HealthPoints = health;
            this.Strength = strength;
        }
    }
}
