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
        static void Main(string[] args)
        {
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
                Random random = new Random();
                Word random_word = dictionary.Words[random.Next(0, dictionary.Words.Count())];
                List<string> sent_struct = random_word.properties.sentence_structures[random.Next(0, random_word.properties.sentence_structures.Count())];
                Boolean first = true;
                foreach (string word_type in sent_struct)
                {
                    if (first)
                    {
                        first = false;
                        if (word_type == "this")
                        {
                            string word = random_word.Name;
                            word = String.Concat(word[0].ToString().ToUpper(), word.Remove(0, 1).ToLower());
                            Console.Write(word);
                        }
                        else
                        {
                            List<Word> options = dictionary.GetWordsOfType(word_type);
                            string word = options[random.Next(0, options.Count())].Name;
                            word = String.Concat(word[0].ToString().ToUpper(), word.Remove(0, 1).ToLower());
                            Console.Write(word);
                        }
                    }
                    else if (word_type == "name")
                    {
                        List<Word> options = dictionary.GetWordsOfType(word_type);
                        string word = options[random.Next(0, options.Count())].Name;
                        word = String.Concat(word[0].ToString().ToUpper(), word.Remove(0, 1).ToLower());
                        Console.Write(" " + word);
                    }
                    else if (word_type == "this" && random_word.properties.Type == "name")
                    {
                        string word = random_word.Name;
                        word = String.Concat(word[0].ToString().ToUpper(), word.Remove(0, 1).ToLower());
                        Console.Write(" " + word);
                    }
                    else
                    {
                        if (word_type == "this")
                            Console.Write(" " + random_word.Name);
                        else
                        {
                            List<Word> options = dictionary.GetWordsOfType(word_type);
                            Console.Write(" " + options[random.Next(0, options.Count())].Name);
                        }
                    }
                }
                Console.Write("\n");
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