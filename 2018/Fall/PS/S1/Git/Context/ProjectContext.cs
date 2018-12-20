using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitC
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("DbConnection")
        { }

        public DbSet<Project> Projects { get; set; }
    }
}
