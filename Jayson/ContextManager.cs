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
        public ContextManager()
        {
            Dictionary<string, byte> wordsInContext = new Dictionary<string, byte>();
        }
        public void Update(string[] words)
        {
            foreach (System.Collections.Generic.KeyValuePair<string, byte> word in wordsInContext)
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
    }
}
