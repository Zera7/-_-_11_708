using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GitC
{
    public class AccountContext : DbContext
    {
        public AccountContext() : base("DbConnection")
        { }

        public DbSet<Account> Accounts { get; set; }
    }
}