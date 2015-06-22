using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jayson
{
    class Program
	{
        static void Main(string[] args)
        {
		    Interface interface_jayson = new Interface();
			while (true) 
			{
				Tuple<string, Int16, string>data = interface_jayson.Read ();
                Console.WriteLine(data);
			}
        }
    }
}
