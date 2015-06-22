using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayson
{
    class Interface
    {
        public Tuple<string, Int16, string> Read()
        {
            String raw_input;
            String[] input;
            String name;
            Int16 type;
            String value;

            raw_input = Console.ReadLine();
            input = raw_input.Split(':');
            try
            {
                name = input[0];
                type = Convert.ToInt16(input[1]);
                value = input[2];
            }
            catch (Exception e)
            {
                return new Tuple<string, Int16, string>("jayson_error", 1, e.ToString());
            }
            
            Tuple<string, Int16, string> data = new Tuple<string, Int16, string>(name, type, value);
            return data;
        }

    }
}
