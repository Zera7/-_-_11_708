using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static readonly string[] StopWords =
        {
            "the", "and", "to", "a", "of", "in", "on", "at", "that",
            "as", "but", "with", "out", "for", "up", "one", "from", "into"
        };

        public static readonly string[] StopWords2 =
        {
            "и","на","в","что","то","бы","не","знаю","был","была","а",
            "я","он","она","они","мы","с","как","раз","еще","ни","чтобы",
            "того", "есть", "от", "к", "нему", "ты", "над", "из", "же",
            "так","вот", "но", "было", "были", "мне", "о", "их", "за", "у",
            "все", "таки", "нет", "или", "может", "это", "них", "по"
        };

        public static readonly char[] Separators = { '!', '?', '.', ';', '(', ')', ':' };

        public static List<List<string>> ParseSentences(string text)
        {
            string[] bufferSentences = text.Split(Separators);
            List<List<string>> sentences = new List<List<string>>();
            StringBuilder word = new StringBuilder(32);
            sentences.Add(new List<string>());

            for (int i = 0; i < bufferSentences.Length; i++)
            {
                if (bufferSentences[i].Length == 0)
                {
                    continue;
                }
                if (sentences[sentences.Count - 1].Count > 0)
                    sentences.Add(new List<string>());
                for (int j = 0; j < bufferSentences[i].Length; j++)
                {
                    if (char.IsLetter(bufferSentences[i][j]) || bufferSentences[i][j] == '\'')
                    {
                        word.Append(bufferSentences[i][j]);
                    }
                    else
                        AddWord(sentences[sentences.Count - 1], word);

                    if (j + 1 == bufferSentences[i].Length)
                        AddWord(sentences[sentences.Count - 1], word);
                }
            }
            if (sentences[sentences.Count - 1].Count == 0) sentences.RemoveAt(sentences.Count - 1);
            return sentences;
        }

        private static void AddWord(List<string> list, StringBuilder word)
        {
            if (word.Length > 0 && !StopWords.Contains(word.ToString().ToLower()))
            {
                list.Add(word.ToString().ToLower());
            }
            word.Clear();
        }
    }
}