using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayson
{
    class SentenceLearner
    {
        String[] yesses = { "yes", "y" };
        JayDictionary dictionary;
        public SentenceLearner(JayDictionary dictionary)
        {
            this.dictionary = dictionary;
        }
        public void learn(List<string[]> sentences)
        {
            string[] structure;
            int i;
            foreach (String[] sentence in sentences)
            {
                structure = new string[sentence.Length];
                i = 0;
                foreach (String word in sentence)
                {
                    string clean_word = new string((from c in word where char.IsLetterOrDigit(c) select c).ToArray());
                    structure[i]=ask_word(clean_word);
                    i++;
                }
                i=0;
                foreach (String word in sentence)
                {
                    dictionary.AddSentenceStructure(new List<string>(structure), word, structure[i], i);
                    i++;
                }
            }
        }
        public string ask_word(string word)
        {
            Console.WriteLine("What type of word is \"" + word + "\" when used in that context?");
            string first_type = Console.ReadLine();
            if (dictionary.Contains(word))
            {
                Console.WriteLine("(\"" + word + "\" found in JayDictionary)");
                {
                    Console.WriteLine("Does the word have a different word type?");
                    if (yesses.Contains(Console.ReadLine().ToLower()))
                    {
                        new_word(word);
                    }
                    else
                    {
                        Console.WriteLine("Thanks");
                    }
                }
            } else {
                new_word(word);
            }
            return first_type;
        }
        private void new_word(String word)
        {
            bool confirmed = false;
            Console.WriteLine("(\"" + word + "\" not found in JayDictionary)");
            int asked =0;
            while (!confirmed)
            {
                if (asked == 0)
                    Console.Write("What word type is \"" + word + "\"? ");
                else
                    Console.Write("What other word type is \"" + word + "\"? ");
                String word_type = Console.ReadLine();
                if (dictionary.word_types.Contains(word_type))
                {
                    dictionary.CreateWord(word, word_type);
                    Console.WriteLine("Done");
                }
                else
                    Console.WriteLine("Type not found in JayDictionary, please add type");
                Console.WriteLine("Is that the only word type for \"" + word + "\"?");
                    if (yesses.Contains(Console.ReadLine().ToLower()))
                        confirmed = true;
                asked++;
            }
        }
    }
}
