using System;
using System.Collections.Generic;
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
        public JayDictionary()
        {
            document = new XmlDocument();
        }
        public void Load()
        {
            document.LoadXml(Properties.Resources.dictionary);
            root = document.FirstChild;
        }

        public string[] GetAllWords()
        {
            Console.WriteLine(root.HasChildNodes);
            List<string> words = new List<string>();
            foreach (XmlNode node in root.ChildNodes)
            {
                foreach (XmlNode node1 in node.ChildNodes)
                {
                    words.Add(node1.Name);
                }
            }
            return words.ToArray();
        }
    }
}
 