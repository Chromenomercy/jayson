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
        public WordProperties properties;
        public Word(string name, WordProperties properties)
        {
            Name = name;
            this.properties = properties;
        }
    }
}
