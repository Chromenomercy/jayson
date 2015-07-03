﻿using System;
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
            JayDictionary dictionary = new JayDictionary();
            dictionary.Load();
            Interface jayInterface = new Interface(dictionary);
            while (true)
            {
                jayInterface.Listen();
            }
        }

    }
}
