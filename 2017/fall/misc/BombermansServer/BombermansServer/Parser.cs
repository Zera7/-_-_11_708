using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BombermansServer
{
    public static class Parser
    {
        private static int LeftFind(string str, char cr)
        {
            if (str == null)
                return -1;
            for (int i = 0; i < str.Length; i++)
                if (str[i] == cr)
                    return i;
            return -1;
        }

        private static int RightFind(string str, char cr)
        {
            if (str == null)
                return -1;
            for (int i = str.Length - 1; i >= 0; i--)
                if (str[i] == cr)
                    return i;
            return -1;
        }

        public static Dictionary<string, string> Parse(string fileName)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            StreamReader Reader = new StreamReader(fileName, Encoding.Default);
            string Line = null;
            while (true)
            {
                Line = Reader.ReadLine();
                if (Line == null)
                    break;
                result.Add(Line.Substring(0, LeftFind(Line, ' ')), Line.Substring(RightFind(Line, ' ') + 1));
            }
            return result;
        }
    }
}
