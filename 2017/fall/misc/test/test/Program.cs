using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Diagnostics;
using NetSerializer;
using System.IO;


public enum Test
{
    first,
    second,
    last
}


namespace Profiling
{
    public static class Program
    {
        static WebClient Client = new WebClient();
        public static Queue<byte[]> Images { get; set; } = new Queue<byte[]>();

        public static void Main()
        {
            var address = "https://www.pinterest.com";
            Console.WriteLine("Начало подключения");
            var result = Client.DownloadString(address).Split(new[]{'\"', '\''})
                .Where(q => q.StartsWith("http") && (q.EndsWith(".jpg") || q.EndsWith(".png") || q.EndsWith(".gif")));
            Console.WriteLine("Конец подключения");
            Parallel.ForEach(result, GetImage);

            Console.WriteLine();

            Console.ReadKey();
        }

        public static void GetImage(string address)
        {
            lock (Client)
            {
                Console.WriteLine($"Загрузка по адресу {address}");
                Client.DownloadFile(address, AppDomain.CurrentDomain.BaseDirectory + "/Images/" + address.Split('/').Last());
            }
        }
    }
}