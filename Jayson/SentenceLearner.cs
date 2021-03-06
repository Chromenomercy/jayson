﻿using System;
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
        public List<Word> Learn(List<string[]> sentences)
        {
            string[] structure;
            int i;
            List<Word> words = new List<Word>();
            foreach (String[] sentence in sentences)
            {
                structure = new string[sentence.Length];
                i = 0;
                List<string> clean_words = new List<string>();
                foreach (String word in sentence)
                {
                    string clean_word = new string((from c in word where char.IsLetterOrDigit(c) select c).ToArray());
                    structure[i]=AskWordType(clean_word);
                    clean_words.Add(clean_word);
                    i++;
                }
                i=0;
                foreach (String word in clean_words)
                {
                    dictionary.AddSentenceStructure(new List<string>(structure), word, structure[i], i);
                    words.Add(dictionary.GetWord(word, structure[i]));
                    i++;
                }
            }
            return words;
        }
        public string AskWordType(string word)
        {
            Console.WriteLine("What type of word is \"" + word + "\" when used in that context?");
            string first_type = Console.ReadLine();
            first_type = NewWord(word, first_type);
            return first_type;
        }
        private string NewWord(String word, String word_type)
        {
            string first_type = word_type;
            if (dictionary.word_types.Contains(word_type))
            {
                dictionary.CreateWord(word, word_type);
                Console.WriteLine("Done");
            }
            else
            {
                Boolean no_type = true;
                Console.WriteLine("Type not found in JayDictionary");
                while (no_type)
                {
                    Console.WriteLine("Is " + word_type + " the correct type?");
                    if (yesses.Contains(Console.ReadLine()))
                    {
                        no_type = false;
                        if (!dictionary.word_types.Contains(word_type))
                        {
                            dictionary.AddType(word_type);
                        }
                        dictionary.CreateWord(word, word_type);
                        first_type = word_type;
                    }
                    else
                    {
                        Console.WriteLine("What is the correct type?");
                        word_type = Console.ReadLine();
                    }
                }
            }
            return first_type;
        }

        internal List<Word> QuickLearn(List<string[]> sentences)
        {
            string[] structure;
            int i;
            List<Word> words = new List<Word>();
            foreach (String[] sentence in sentences)
            {
                structure = new string[sentence.Length];
                i = 0;
                List<string> clean_words = new List<string>();
                foreach (String word in sentence)
                {
                    string clean_word = new string((from c in word where char.IsLetterOrDigit(c) select c).ToArray());
                    structure[i] = GetWordType(clean_word);
                    clean_words.Add(clean_word);
                    i++;
                }
                i = 0;
                foreach (String word in clean_words)
                {
                    dictionary.AddSentenceStructure(new List<string>(structure), word, structure[i], i);
                    words.Add(dictionary.GetWord(word, structure[i]));
                    i++;
                }
            }
            return words;
        }

        private string GetWordType(string clean_word)
        {
            List<string> types = dictionary.GetTypes(clean_word);
            if (types.Count == 0)
            {
                throw new WordNotFoundException(clean_word);
            }
            else
            {
                return types[0];
            }
        }
    }
    class WordNotFoundException : Exception
    {
        public WordNotFoundException(string clean_word)
            : base("Word not found: " + clean_word) { }

    }
}