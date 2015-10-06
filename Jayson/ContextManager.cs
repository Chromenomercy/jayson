using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayson
{
    class ContextManager
    {
        Dictionary<Word, byte> wordsInContext;
        Word defaultWord;
        public ContextManager(Word defaultWord)
        {
            wordsInContext = new Dictionary<Word, byte>();
            this.defaultWord = defaultWord;
        }
        public void Update(List<Word> words)
        {
            foreach (KeyValuePair<Word, byte> word in new Dictionary<Word, byte>(wordsInContext))
            {
                if (word.Value == 1)
                {
                    wordsInContext.Remove(word.Key);
                }
                else
                {
                    wordsInContext[word.Key] -= 1;
                }
            }
            foreach (Word word in words)
            {
                if (wordsInContext.ContainsKey(word))
                {
                    wordsInContext[word] = 5;
                }
                else
                {
                    wordsInContext.Add(word, 5);
                }
            }
        }
        public Word GetWord()
        {
            int total = 0;
            List<Word> possibleWords = new List<Word>();
            possibleWords.Add(defaultWord);
            foreach (KeyValuePair<Word, byte> word in wordsInContext)
            {
                total += word.Value;
                for (int i = 0; i < word.Value; i++)
                {
                    possibleWords.Add(word.Key);
                }
            }
            return possibleWords[new Random().Next(0, total)];
        }
    }
}
