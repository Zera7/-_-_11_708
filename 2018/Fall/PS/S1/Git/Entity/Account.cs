using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitC
{
    public class Account
    {
        public Account() { }
        public Account(
            string userNickName,
            string userLogin,
            string userPassword,
            string userEmail,
            int userId,
            List<Commit> commits,
            List<Project> projects)
        {
            this.NickName = userNickName;
            this.Login = userLogin;
            this.Password = userPassword;
            this.Email = userEmail;
            this.Commits = commits;
            this.Projects = projects;
        }

        public int Id { get; set; }
        public string NickName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        // Связи
        public List<Commit> Commits { get; set; }
        public List<Project> Projects { get; set; }
        
        public override string ToString()
        {
            return
                "Nick : " + this.NickName +
                " Login : " + this.Login +
                " Email : " + this.Email +
                " ID : " + this.Id;
        }

    }
}
