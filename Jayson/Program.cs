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
        static ContextManager contextManager;

        static void Main(string[] args)
        {
            random = new Random();
            dictionary = new JayDictionary();
            dictionary.Load();
            jayInterface = new Interface(dictionary);
            learner = new SentenceLearner(dictionary);
            contextManager = new ContextManager(dictionary.Words[0]);
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
                //Word random_word = dictionary.Words[random.Next(0, dictionary.Words.Count())];
                Word random_word = contextManager.GetWord();
                List<string> sent_struct = random_word.sentence_structures[random.Next(0, random_word.sentence_structures.Count())];
                List<Word> words = new List<Word>();
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
                        words.Add(random_word);
                    }
                    else
                    {
                            List<Word> options = dictionary.GetWordsOfType(word_type);
                            words.Add(options[random.Next(0, options.Count())]);
                    }

                    if (word_type == "name" || (word_type == "this" && random_word.Type == "name"))
                        capitals[i] = true;
                }

                jayInterface.Write(words, capitals);
            }
        }

        public static void Learn()
        {
            contextManager.Update(learner.learn(jayInterface.Read()));
            dictionary.SaveAll();
        }
    }
}