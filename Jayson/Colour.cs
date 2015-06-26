using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayson
{
    class Colour:JayObject<Tuple<Int16, Int16, Int16>>
    {
        string name;
        Tuple<short, short, short> jValue;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public Tuple<short, short, short> Value
        {
            get
            {
                return jValue;
            }
            set
            {
                jValue = value;
            }
        }
    }
}
