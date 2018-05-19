using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermansServer
{
    public static class Game
    {
        public static int MaxLobbyNumber { get; set; }

        public static Dictionary<double, Lobby> Lobbies { get; set; } = new Dictionary<double, Lobby>();
    }
}
