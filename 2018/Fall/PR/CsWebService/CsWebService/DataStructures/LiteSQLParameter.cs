using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsWebService
{
    public struct LiteSQLParameter
    {
        public LiteSQLParameter(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; }
        public string Value { get; }
    }
}