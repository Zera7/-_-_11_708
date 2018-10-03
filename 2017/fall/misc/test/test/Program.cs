using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Diagnostics;
using NetSerializer;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using CsQuery;
using AngleSharp;
using AngleSharp.Parser.Html;
using AngleSharp.Parser.Css;

namespace Profiling
{
    internal class ClassA { }

    internal class ClassB
    {
        public ClassA Method1() { return null; }
        private ClassB Method2() { return null; }
    }
}