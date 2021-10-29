﻿using Neo.IronLua;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skymly.NeoLuaSamples.ConsoleApp
{
    public class Sample07_CallConstructor : BaseSample
    {
        public Sample07_CallConstructor()
        {

        }

        public override void Run()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("Scripts/Sample07.lua");
        }
    }
}
