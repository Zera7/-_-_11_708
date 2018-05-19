using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermansServer
{
    // Дописать
    public class Lobby
    {
        public static double CurrentIndexLobby { get; set; } = 0;
        public double IdLobby { get; set; }
        Dictionary<IPEndPoint, Player> Players { get; set; }
        Map Map { get; set; }

        public Lobby(string mapName)
        {

        }

        public Lobby()
        {
            while (true)
            {
                if (CurrentIndexLobby == double.MaxValue)
                    CurrentIndexLobby = 0;
                if (Game.Lobbies.ContainsKey(CurrentIndexLobby))
                    CurrentIndexLobby++;
                else
                    break;
            }
            this.IdLobby = CurrentIndexLobby;
        }

        public void AddPlayer(string name, IPEndPoint address)
        {
            Players.Add(address, Player.GetPlayer(GetUniqueName(name), IdLobby, address));
        }

        private string GetUniqueName(string name)
        {
            if (Players.Any(q => q.Value.Name == name))
            {
                int index = 1;
                while (true)
                {
                    if (Players.Any(q => q.Value.Name == name + $"({index})"))
                        index++;
                    else
                    {
                        name += $"({index})";
                        break;
                    }
                }
            }
            return name;
        }
    }
}