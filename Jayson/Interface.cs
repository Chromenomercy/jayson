using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Data;

namespace Jayson
{
    public class Interface
    {
        public Interface(JayDictionary dictionary)
        {
            Console.WriteLine("Hi, I'm Jason. Give me a sentence to learn!");
        }
        public List<String[]> Read()
        {
            List<String[]> sentences = new List<String[]>();
            String raw_input;

            raw_input = Console.ReadLine().ToLower();
            if (raw_input != "")
                foreach (String sentence in raw_input.Split('.'))
                    sentences.Add(sentence.Split(' '));
            return sentences;
        }
        public void Write(List<string> words, Boolean[] capitals)
        {
            int i = 0;
            foreach (string word in words)
            {
                if (i != 0)
                {
                    Console.Write(" ");
                }
                if (capitals[i])
                    Console.Write(String.Concat(word[0].ToString().ToUpper(), word.Remove(0, 1).ToLower()));
                else
                    Console.Write(word);
               i++;
            }
            Console.Write(".\n");
        }
    }
}
