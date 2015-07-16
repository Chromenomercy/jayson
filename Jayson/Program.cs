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