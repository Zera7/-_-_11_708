using System.Collections.Generic;

namespace TextAnalysis
{
    static class BigramGeneratorTask
    {
        public static string ContinuePhraseWithBigramms(
            Dictionary<string, string> mostFrequentNextWords,
            string phraseBeginning,
            int phraseWordsCount)
        {
            string lastWord = phraseBeginning;
            for (int i = 1; i < phraseWordsCount; i++)
            {
                if (mostFrequentNextWords.ContainsKey(lastWord))
                    phraseBeginning += " " + mostFrequentNextWords[lastWord];
                else
                    break;
                lastWord = mostFrequentNextWords[lastWord];
            }
            return phraseBeginning;
        }
    }
}