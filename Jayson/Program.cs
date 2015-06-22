using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Jayson.Interface;

namespace Jayson
{
    class Program
	{
		Object interface_Jayson = new Interface();

        static void Main(string[] args)
        {
			while (true) 
			{
				interface_Jayson.Read ();
			}
        }
    }
}
