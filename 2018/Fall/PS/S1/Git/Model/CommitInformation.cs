using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitC
{
    public class CommitInformation
    {
        public CommitInformation() { }
        public CommitInformation(Version version, DateTime date, string description)
        {
            this.Version = version;
            this.Date = date;
            this.Description = description;
        }

        Version Version { get; set; }
        DateTime Date { get; set; }
        string Description { get; set; }
    }
}
