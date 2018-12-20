using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitC
{
    public class Commit
    {
        public Commit() { }
        public Commit(string code, Account autor, string description,DateTime date,string version,Project project)
        {
            this.Code = code;
            this.Autor = autor;
            this.Description = description;
            this.Date = date;
            this.Number = version;
            this.Project = project;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Code { get; set; }
        public string Number { get; set; }
        public string Article { get; set; }
        public string Description { get; set; }

        // Связи
        public Account Autor { get; set; }
        public Project Project { get; set; }

        public override string ToString()
        {
            return "date : " + Date.ToString() + " : By " + Autor.NickName + " version : " + Code.ToString() + " description : " + Description;
        }
    }
}