using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitC
{
    public class Version
    {
        public Version() { }
        public Version(string number, string article)
        {
            this.Number = number;
            this.Article = article;
        }

        public string Number { get; set; }
        public string Article { get; set; }
        
        public override string ToString()
        {
            if (Article.Length > 0)
                return Number.ToString() + "." + Article.ToString();
            return Number.ToString();
        }
    }
}
