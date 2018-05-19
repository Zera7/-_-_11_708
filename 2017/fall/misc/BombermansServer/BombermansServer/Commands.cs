using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NetSerializer;

namespace BombermansServer
{
    public static class Commands
    {
        public static Queue<Message> messages = new Queue<Message>();
        public static void AddCommand(Message message, Connector sender)
        {
            messages.Enqueue(message);
        }

        public static void ExecuteCommands()
        {
            // Добавить сериализатор
            // var qwe = new Serializer(new Type[] { });
            while (true)
            {
                if (messages.Count > 0)
                {
                    var msg = messages.Dequeue();
                    var command = Encoding.UTF8.GetString(msg.Content).Split(' ');

                    switch ((ClientToServerCommands)command[0][0])
                    {
                        case ClientToServerCommands.ConnectToGame:
                            Console.WriteLine("Получен запрос на добавление пользователя");
                            ConnectToLobby(command, msg.Address);
                            break;
                        case ClientToServerCommands.StartMoving:
                            StartMoving();
                            break;
                        case ClientToServerCommands.EndMoving:
                            break;
                        case ClientToServerCommands.BombPlanted:
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        // Дописать
        private static void ConnectToLobby(string[] msg, IPEndPoint address)
        {
            if (Game.Lobbies.Count < Game.MaxLobbyNumber)
            {
                Game.CurrentLobby.AddPlayer(msg[1], address);
            }
            else
            {
                // TODO отклонить подключение
            }
                
        }
    }
}
