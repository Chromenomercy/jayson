using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayson
{
    class ContextManager
    {
        Dictionary<string, byte> wordsInContext;
        string defaultWord;
        public ContextManager(string defaultWord)
        {
            Dictionary<string, byte> wordsInContext = new Dictionary<string, byte>();
            this.defaultWord = defaultWord;
        }
        public void Update(string[] words)
        {
            foreach (KeyValuePair<string, byte> word in wordsInContext)
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
            foreach (string word in words)
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
        public string GetWord()
        {
            KeyValuePair<string, byte> highest = new KeyValuePair<string, byte>(defaultWord, 1);
            foreach (KeyValuePair<string, byte> word in wordsInContext)
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
