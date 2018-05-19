using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace BombermansServer
{
    public class Player : GameObject
    {
        private Player(string name, double idLobby, IPEndPoint address, int strength, int health) : base(health, strength)
        {
            this.Name = name;
            this.IdLobby = idLobby;
            this.Address = address;
            // TODO
            // Скопировать из прошлой игры метод проверки (< 10)
        }

        public Coords2DDouble Coords { get; set; }

        public string Name { get; set; }
        public byte IdPlayer { get; set; }
        public double IdLobby { get; set; }

        public IPEndPoint Address { get; set; }

        int power = 1, speed = 1, bombs = 1;

        public int Power { get; set; }
        public int Speed { get; set; }
        public int Bombs { get; set; }

        public static Player GetPlayer(string name, double lobby, IPEndPoint address)
        {
            return new Player(name, lobby, address, 1, 1);
        }
    }
}
