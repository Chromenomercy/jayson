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
                file.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<dictionary>\n  <name>\n        <jason></jason>\n   </name>\n</dictionary>");
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
                    types.Add(word.properties.Type);
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
                    string[] contexts = {};
                    XmlNodeList nodes = node1.ChildNodes;
                    foreach(XmlNode property in nodes){
                        if (property.Name == "contexts")
                        {
                            contexts = property.InnerText.Split(new string[] {","}, StringSplitOptions.None);
                        }
                    }
                    words.Add(new Word(node1.Name, new WordProperties(node.Name, contexts)));
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
                if (word.Name == word_name && word.properties.Type == word_type)
                    existing = true;
            
            if(!existing)
                Words.Add(new Word(word_name, new WordProperties(word_type)));
        }
        public void PrintAll()
        {
            foreach(Word word in Words)
            {
                Console.WriteLine(word.Name + ": " + word.properties.Type);
            }
        }
    } 
}
 