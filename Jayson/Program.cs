using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace Jayson
{
    class Program
    {
        static void Main(string[] args)
        {
            Interface jayInterface = new Interface();
            while (true)
            {
                //jayInterface.Say(Convert.ToString(jayInterface.Read()));
                jayInterface.Listen();
            }
        }

    }
}
