using System.Collections.Generic;
using System;
namespace TableParser
{
	public class FieldsParserTask
	{
        // При решении этой задаче постарайтесь избежать создания методов, длиннее 10 строк.
        // Ниже есть метод ReadField — это подсказка. Найдите класс Token и изучите его.
        // Подумайте как можно использовать ReadField и Token в этой задаче.
        public static List<string> ParseLine(string line)
        {
            List<string> fields = new List<string>();
            Token token;
            int startIndex = 0;
            do
            {
                token = ReadField(line, startIndex);
                if (token.Length != 0)
                    fields.Add(token.Value);
                startIndex = token.StartIndex + token.Length;
            } while (token.StartIndex + token.Length < line.Length);
            return fields; // сокращенный синтаксис для инициализации коллекции.
        }

        private static Token ReadField(string line, int startIndex)
		{
            for (; startIndex < line.Length && line[startIndex] == ' '; startIndex++) ;
            if (startIndex >= line.Length) return new Token("", startIndex, 0);

            if (line[startIndex] == '\'' || line[startIndex] == '\"') return GetHardToken(line, startIndex);
            else return GetSimpleToken(line, startIndex);
		}

        private static Token GetSimpleToken(string line, int startIndex)
        {
            string str = "";
            for (int i = startIndex; i < line.Length && line[i] != ' ' && line[i] != '\"' && line[i] != '\''; i++)
            {
                str += line[i];
            }
            return new Token(str, startIndex, str.Length);
        }

        private static Token GetHardToken(string line, int startIndex)
        {
            string str = "";
            bool ekr = false, end = false;
            char quotes = line[startIndex];
            int strLength = 1;
            for (int i = startIndex + 1; i < line.Length && !end; i++)
            {
                strLength++;
                if (line[i] == quotes && !ekr)
                {
                    end = true;
                }
                if (!ekr && line[i] == '\\') {
                    ekr = true;
                    continue;
                }
                if (!end && (ekr || line[i] != '\\')) {
                    str+= line[i];
                    ekr = false;
                }
            }
            return new Token(str, startIndex, strLength);
        }
    }
}