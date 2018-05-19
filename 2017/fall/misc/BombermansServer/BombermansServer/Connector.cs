using System;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace BombermansServer
{
    public struct Message
    {
        public byte[] Content;
        public IPEndPoint Address;
    }

    public class Connector
    {
        public readonly UdpClient UdpClient;
        public event Action<Message, Connector> OnReseive;
        public IPEndPoint LastReseivePoint { get => lastReseivePoint; }

        private IPEndPoint lastReseivePoint = null;
        private Thread receiverThread;

        public Connector(int receivePort)
        {
            UdpClient = new UdpClient(receivePort);
        }

        public void Start()
        {
            receiverThread = new Thread(Receive);
            receiverThread.Start();
        }

        public void Stop()
        {
            if (receiverThread != null && receiverThread.IsAlive)
                receiverThread.Abort();
            UdpClient.Close();
        }

        private void Receive()
        {
            while (true)
            {
                byte[] bytes = UdpClient.Receive(ref lastReseivePoint);
                OnReseive?.Invoke(new Message
                {
                    Address = LastReseivePoint,
                    Content = bytes
                }, this);
            }
        }

        public void Send(string message, IPEndPoint endPoint)
        {
            Send(GetBytesFromString(message), endPoint);
        }

        public void Send(byte[] message, IPEndPoint endPoint)
        {
            try
            {
                UdpClient.Send(message, message.Length, endPoint);
            }
            catch (Exception)
            {
                // TODO
                // Сделать вывод ошибки
            }
        }

        public static byte[] GetBytesFromString(string a)
        {
            return Encoding.UTF8.GetBytes(a);
        }
    }
}