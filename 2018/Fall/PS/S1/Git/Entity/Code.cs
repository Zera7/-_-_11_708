using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitC
{
    public class Code
    {
        public Code() { }
        public Code(List<string> code, Version version)
        {
            this.Text = code;
            this.Version = version;
        }

        public List<string> Text { get; set; }
        public Version Version { get; set; }
        
        public override string ToString() => Version.ToString();
    }
}
