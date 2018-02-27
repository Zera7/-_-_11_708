using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            return GetResultDictionary((GetBufferDictionary(text)));
        }

        public static Dictionary<string, Dictionary<string, int>> GetBufferDictionary(List<List<string>> text)
        {
            Dictionary<string, Dictionary<string, int>> bufferDictionary =
                new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < text.Count; i++)
            {
                for (int j = 0; j < text[i].Count - 1; j++)
                {
                    if (!bufferDictionary.ContainsKey(text[i][j]))
                    {
                        bufferDictionary.Add(text[i][j], new Dictionary<string, int>());
                        bufferDictionary[text[i][j]].Add(text[i][j + 1], 1);
                    }
                    else if (!bufferDictionary[text[i][j]].ContainsKey(text[i][j + 1]))
                    {
                        bufferDictionary[text[i][j]].Add(text[i][j + 1], 1);
                    }
                    else
                        bufferDictionary[text[i][j]][text[i][j + 1]]++;
                }
            }
            return bufferDictionary;
        }

        public static Dictionary<string, string> GetResultDictionary(
            Dictionary<string,
             Dictionary<string, int>> bufferDictionary)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            var dictionaryKeys1 = bufferDictionary.Keys;
            foreach (var i in bufferDictionary.Keys)
            {
                string maxWord = "";
                int max = 0;
                foreach (var j in bufferDictionary[i].Keys)
                {
                    if (bufferDictionary[i][j] > max || (bufferDictionary[i][j] == max
                        && string.CompareOrdinal(j, maxWord) < 0))
                    {
                        max = bufferDictionary[i][j];
                        maxWord = j;
                    }
                }
                dictionary.Add(i, maxWord);
            }
            return dictionary;
        }
    }
}