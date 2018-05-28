using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Linq;

namespace Contra
{
    class Program2
    {
        // Задание 2 
        // Заменить на Main для теста
        static void Main2(string[] args)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            List<char> chars = new List<char> { 'q', 'w', 'r', 't', 'p', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm' };
            List<object> list = new List<object>();
            string str;
            int count = 0;

            // Добавление элементов для получения их списка методов
            list.Add(new List<int> { 1, 2, 3 });
            list.Add(new Dictionary<int, char>());

            // Цикл обходит все объекты
            for (int i = 0; i < list.Count; i++)
            {
                var type = list[i].GetType();
                var methodInfo = type.GetMethods();

                // Цикл обходит все методы объекта
                for (int j = 0; j < methodInfo.Length; j++)
                {
                    count = 0;
                    str = methodInfo[j].Name.ToLower();

                    for (int k = 0; k < str.Length; k++)
                        for (int w = 0; w < chars.Count; w++)
                        {
                            if (str[k] == chars[w])
                                count++;
                        }

                    if (count % 2 == 0)
                    {
                        Console.WriteLine(methodInfo[j].Name.ToString());
                        json.Serialize(methodInfo[j].Name.ToString());
                    }
                }
            }
        }
    }
}
