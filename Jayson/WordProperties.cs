using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayson
{
    public class WordProperties
    {
        public List<string> descriptors;
        public List<List<string>> sentense_structures;
        public string Type;
        private System.Xml.XmlNodeList xmlchildren;
        public WordProperties(string Type)
        {
            this.Type = Type;
        }

        public WordProperties(string Type, System.Xml.XmlNodeList xmlchildren)
        {
            this.Type = Type;
            this.xmlchildren = xmlchildren;
        }
    }
}
