using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public class Server
    {
        private Connector connector; 

        public readonly int PortServer;
        public readonly int PortClient;
        public readonly int CountOfPlayers;

        public const string command = "hi";

        private bool isStarted = false;

        public Server(int portServer, int portClient, int countOfPlayers)
        {
            this.PortServer = portServer;
            this.PortClient = portClient;
            this.CountOfPlayers = countOfPlayers;
            this.connector = new Connector(new IPEndPoint(IPAddress.Broadcast, PortClient), PortServer);
        }

        private void CreateLobby()
        {
            connector.Start();
            while (!this.isStarted)
            {
                if (connector.Clients.Count < CountOfPlayers)
                {
                    connector.Send("hi", connector.SenderDefaultEndPoint);
                    for (int i = 0; i < connector.AllMessages.Count;)
                    {
                        string[] message = Encoding.UTF8.GetString(connector.AllMessages[0].Message).Split(' ');
                        if (message[0] == "new")
                        {
                            connector.Send("+new", connector.AllMessages[0].Address);
                            connector.Clients.Add(connector.AllMessages[0].Address);
                            Console.WriteLine("К серверу добавлен новый клиент:" + connector.AllMessages[0].Address);
                        }
                        connector.AllMessages.RemoveAt(0);
                    }
                }
                else
                {
                    Game.isReadyToStart = true;
                    connector.AllMessages.Clear();
                    break;
                }
                Thread.Sleep(500);
            }
            Console.WriteLine("Лобби собрано");
        }
    }
}
