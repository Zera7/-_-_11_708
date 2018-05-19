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
        public static void Main()
        {
            var types = new List<Type>
            {
                typeof(int)
            };
            Stream stream = Stream.Null.BeginWrite();
            Serializer serializer = new Serializer(types);
            serializer.Serialize(5);
            
            

            Console.WriteLine(serializer.Deserialize(stream));
            Console.Read();
        }
    }
}