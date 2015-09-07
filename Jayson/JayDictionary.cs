using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Jayson
{
    public class JayDictionary
    {
        XmlDocument document;
        XmlNode root;
        public List<Word> Words;
        string directory_path;
        string dictionary_path;
        public List<string> word_types;
        public JayDictionary()
        {
            document = new XmlDocument(); 
            directory_path = Path.Combine(
                 Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                 @"jason_ai"
             );
            dictionary_path = Path.Combine(directory_path, @"dictionary.xml");
        }
        public void Load()
        {
            Directory.CreateDirectory(directory_path);
            if (!File.Exists(dictionary_path))
            {
                StreamWriter file = File.CreateText(dictionary_path);
                file.Write("<dictionary>\n<name>\n<jason/>\n</name>\n</dictionary>");
                file.Close();
            }
            document.Load(dictionary_path);
            root = document.LastChild;
            Words = GetAllWords();
        }

        public List<string> GetTypes(String WordName)
        {
            List<string> types = new List<string>();
            foreach (Word word in Words)
                if (WordName == word.Name)
                    types.Add(word.Type);
            return types;
 
        }

        private List<Word> GetAllWords()
        {
            List<Word> words = new List<Word>();
            word_types = new List<string>();
            foreach (XmlNode node in root.ChildNodes)
            {
                word_types.Add(node.Name);
                foreach (XmlNode node1 in node.ChildNodes)
                {
                    List<List<string>> sentence_structures = new List<List<string>>();
                    XmlNodeList nodes = node1.ChildNodes;
                    foreach(XmlNode property in nodes){
                        if (property.Name == "sentence_structures")
                        {
                            foreach (string raw_sentence_structure in property.InnerText.Split('.'))
                            {
                                List<string> sentence_structure = new List<string>();
                                foreach (string raw_word_type in raw_sentence_structure.Split(' '))
                                {
                                    sentence_structure.Add(raw_word_type);
                                }
                                sentence_structures.Add(sentence_structure);
                            }
                        }
                    }
                    words.Add(new Word(node1.Name, node.Name, sentence_structures));
                }
            }
            return words;
        }

        public Boolean Contains(String name)
        {
            foreach (Word word in Words)
                if (name == word.Name)
                    return true;
            return false;
        }

        public void CreateWord(string word_name, string word_type)
        {
            Boolean existing = false;
            foreach(Word word in Words)
                if (word.Name == word_name && word.Type == word_type)
                    existing = true;
            
            if(!existing)
                Words.Add(new Word(word_name, word_type));
        }
        public void PrintAll()
        {
            foreach(Word word in Words)
            {
                Console.WriteLine(word.Name + ": " + word.Type);
            }
        }
        public void SaveAll()
        {
            XmlDocument NewDocument = new XmlDocument();
            XmlNode rootNode = NewDocument.CreateElement("dictionary");
            NewDocument.AppendChild(rootNode);
            foreach (string type in word_types)
            {
                XmlNode typeNode = NewDocument.CreateElement(type);
                rootNode.AppendChild(typeNode);
            }
            int i;
            foreach (Word word in Words)
            {
                XmlNode WordNode = NewDocument.CreateElement(word.Name);
                XmlNode SentenceStructures = NewDocument.CreateElement("sentence_structures");
                string raw_sentence_structures = "";
                foreach (List<string> sentence_structure in word.sentence_structures)
                {
                    if (raw_sentence_structures!="")
                        raw_sentence_structures += ".";
                    i = 0;
                    foreach (string word_type in sentence_structure)
                    {
                        if (i != 0)
                            raw_sentence_structures += " ";
                        else
                            i = 1;
                        raw_sentence_structures = raw_sentence_structures + word_type;
                    }
                }
                SentenceStructures.InnerText = raw_sentence_structures;
                WordNode.AppendChild(SentenceStructures);
                foreach (XmlNode type in rootNode.ChildNodes)
                    if (type.Name == word.Type)
                        type.AppendChild(WordNode);
                
            }
            NewDocument.Save(dictionary_path);
        }
        public void AddSentenceStructure(List<string> sentence_structure, string WordName, string WordType, int indexOfWord)
        {
            sentence_structure[indexOfWord] = "this";
            foreach (Word word in Words)
                if (word.Name == WordName && word.Type == WordType)
                    word.sentence_structures.Add(sentence_structure);
        }
        public List<Word> GetWordsOfType(string type)
        {
            List<Word> words = new List<Word>();
            foreach (Word word in Words)
            {
                if (word.Type == type)
                    words.Add(word);
            }
            return words;
        }

        internal void AddType(string word_type)
        {
            word_types.Add(word_type);
        }
    }
}
 