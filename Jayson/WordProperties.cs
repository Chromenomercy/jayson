using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayson
{
    public class WordProperties
    {
        public List<List<string>> sentence_structures;
        public string Type;
        private string[] contexts;
        public WordProperties(string Type)
        {
            this.Type = Type;
            this.sentence_structures = new List<List<string>>();
        }

        public WordProperties(string Type, List<List<string>> sentence_structures)
        {
            this.Type = Type;
            this.sentence_structures = sentence_structures;
        }
    }
}
