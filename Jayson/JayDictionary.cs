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
        public Word[] Words;
        string directory_path;
        string dictionary_path;
        List<string> word_types;
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

        private Word[] GetAllWords()
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
            return words.ToArray();
        }
    }
}
 