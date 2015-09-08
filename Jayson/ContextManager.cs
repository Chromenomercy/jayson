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
                    wordsInContext[word] += 10;
                }
                else
                {
                    wordsInContext.Add(word, 10);
                }
            }
        }
        public Word GetWord()
        {
            KeyValuePair<Word, byte> highest = new KeyValuePair<Word, byte>(defaultWord, 1);
            foreach (KeyValuePair<Word, byte> word in wordsInContext)
            {
                if (highest.Value < word.Value)
                {
                    highest = word;
                }
            }
            return highest.Key;
        }
    }
}
