using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayson
{
    class SentenceLearner
    {
        JayDictionary dictionary;
        public SentenceLearner(JayDictionary dictionary)
        {
            this.dictionary = dictionary;
        }
        public void learn(List<string[]> sentences)
        {
            foreach (String[] sentence in sentences)
                foreach (String word in sentence)
                    ask_word(word);
        }
        public void ask_word(string word)
        {
            String[] yesses = {"yes", "y"};
            if (dictionary.Contains(word))
            {
                Console.WriteLine(word + " found in JayDictionary");
                foreach (String ex_word_type in dictionary.GetTypes(word))
                {
                    Console.WriteLine("Is " + word + " a " + ex_word_type + "? ");
                    Console.WriteLine("Thank you");
                }
                Boolean confirmed = false;
                while (!confirmed)
                {
                    Console.WriteLine("Does the word have a different word type?");
                    if (yesses.Contains(Console.ReadLine().ToLower()))
                    {
                        new_word(word);
                    }
                    else
                    {
                        Console.WriteLine("Thanks");
                        confirmed = false;
                    }
                }
            }

            else
            {
                new_word(word);
            }
        }
        private void new_word(String word)
            {
                Console.WriteLine(word + " not found in JayDictionary");
                Console.Write("what word type is " + word + "? ");
                String word_type = Console.ReadLine();
                if (dictionary.word_types.Contains(word_type))
                    Console.WriteLine("Done");
                else
                    Console.WriteLine("Not found in JayDictionary, please add type");
            }
    }
}
