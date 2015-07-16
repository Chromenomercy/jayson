using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace Jayson
{
    class Program
    {
        static void Main(string[] args)
        {
            JayDictionary dictionary = new JayDictionary();
            dictionary.Load();
            Interface jayInterface = new Interface(dictionary);
            SentenceLearner learner = new SentenceLearner(dictionary);
            bool running = true;
            while (true)
            {
                Word random_word = dictionary.Words[new Random().Next(0, dictionary.Words.Count())];
                List<string> sent_struct = random_word.properties.sentence_structures[new Random().Next(0, random_word.properties.sentence_structures.Count())];
                foreach (string word_type in sent_struct)
                {
                    if (word_type == "this")
                        Console.Write(" " + random_word.Name);
                    else
                    {
                        List<Word> options = dictionary.GetWordsOfType(word_type);
                        Console.Write(" " + options[new Random().Next(0, options.Count())].Name);
                    }
                }
                Console.Write("\n");
                Console.ReadLine();
            }
            while (running)
            {
                List<string[]> output = jayInterface.Read();
                learner.learn(output);
                foreach (String[] sentence in output)
                {
                    foreach(String word in sentence)
                    {
                        if ("bye goodbye cya".Contains(word.ToLower()))
                        {
                            running = false;
                            Console.WriteLine("Goodbye");
                            Console.ReadLine();
                            dictionary.SaveAll();
                            dictionary.PrintAll();
                            Console.ReadLine();
                        }
                    }
                }
            }
        }
    }
}