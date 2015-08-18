using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace Jayson
{
    class Program
    {
        static JayDictionary dictionary;
        static Interface jayInterface;
        static SentenceLearner learner;
        static Boolean running;
        static Random random;

        static void Main(string[] args)
        {
            random = new Random();
            dictionary = new JayDictionary();
            dictionary.Load();
            jayInterface = new Interface(dictionary);
            learner = new SentenceLearner(dictionary);
            running = true;
            while (running)
            {
                Learn();
                Write();
            }
        }

        public static void Write()
        {
            if (running)
            {
                Word random_word = dictionary.Words[random.Next(0, dictionary.Words.Count())];
                List<string> sent_struct = random_word.sentence_structures[random.Next(0, random_word.sentence_structures.Count())];
                List<string> words = new List<string>();
                Boolean[] capitals = new Boolean[sent_struct.Count];
                int i = 0;

                foreach (string word_type in sent_struct)
                {
                    if (i==0)
                        capitals[i] = true;
                    else
                        capitals[i] = false;

                    if(word_type=="this")
                    {
                        words.Add(random_word.Name);
                    }
                    else
                    {
                            List<Word> options = dictionary.GetWordsOfType(word_type);
                            words.Add(options[random.Next(0, options.Count())].Name);
                    }

                    if (word_type == "name" || (word_type == "this" && random_word.properties.Type == "name"))
                        capitals[i] = true;
                }

                jayInterface.Write(words, capitals);
            }
        }

        public static void Learn()
        {
            List<string[]> output = jayInterface.Read(); 
            foreach (String[] sentence in output)
            {
                if ("bye goodbye cya".Contains(sentence[0].ToLower()))
                {
                    running = false;
                    Console.WriteLine("Goodbye");
                    Console.ReadLine();
                }

            }

            learner.learn(output);
            dictionary.SaveAll();
        }
    }
}