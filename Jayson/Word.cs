using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayson
{
    public class Word
    {
        public string Name;
        public Int16 current_focus;
        public List<List<string>> sentence_structures;
        public string Type;
        public Word(string name, string Type, List<List<string>> sentence_structures)
        {
            Name = name;
            this.Type = Type;
            this.sentence_structures = sentence_structures;
        }
        public Word(string name, string Type)
        {
            Name = name;
            this.Type = Type;
            this.sentence_structures = new List<List<string>>();
        }
    }
}
