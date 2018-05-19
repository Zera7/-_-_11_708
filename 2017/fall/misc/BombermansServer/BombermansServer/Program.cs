using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace BombermansServer
{
    static class Program
    {
        public const string SettingsPath = "Settings.txt";

        static void Main(string[] args)
        {
            var settings = Parser.Parse("Settings.txt");

            var ReceivePort = int.Parse(settings["receive_port"]);
            var SendPort = int.Parse(settings["send_port"]);
            var MapsPath = settings["maps_path"];
            Game.MaxLobbyNumber = int.Parse(settings["max_lobby_index"]);

            var map = new Map();
            map.DownloadMap(MapsPath + "1.txt");

            Connector connector = new Connector(ReceivePort);
            connector.OnReseive += Commands.AddCommand;
            connector.Start();

            var ExecThread = BeginExecuteCommands();

            ControlServer();   
        }

        private static void ControlServer()
        {
            while (true)
            {
                var a = Console.ReadLine();
                switch (a)
                {
                    case "end":
                        Server.StopServer();
                        break;
                    default:
                        break;
                }
            }
        }

        private static Thread BeginExecuteCommands()
        {
            var thread = new Thread(Commands.ExecuteCommands);
            thread.Start();
            return thread;
        }
    }
}