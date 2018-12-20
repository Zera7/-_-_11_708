using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitC
{
    public class Project
    {
        public Project() { }
        public Project(
            string name,
            List<Account> developers,
            List<Commit> commits,
            string description)
        {
            this.Developers = developers;
            this.Commits = commits;
            this.Description = description;
            this.Name = name;
        }
        

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Связи
        
        [ForeignKey("Id")]
        public List<Account> Developers { get; set; }
        [ForeignKey("Id")]
        public List<Commit> Commits { get; set; }

        public override string ToString() => $"name : {Name}";
    }
}
