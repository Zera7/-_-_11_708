using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitC
{
    public class GitController : IGitController
    {
        public GitController() { }

        public bool AddDeveloper(Project project, Account account)
        {
            using (var projectContext = new ProjectContext())
            {
                project.Developers.Add(account);
                projectContext.SaveChanges();
            }
            return true;
        }

        public bool Commit(Commit commit)
        {
            using (var commitContext = new CommitContext())
            {
                commitContext.Commits.Add(commit);
                commitContext.SaveChanges();
            }
            return true;
        }

        public bool CreateProject(Project project)
        {
            using (var a = new AccountContext())
            using (var b = new CommitContext()) 
            using (var projectContext = new ProjectContext())
            {
                projectContext.Projects.Add(project);
                projectContext.SaveChanges();
            }
            return true;
        }

        public bool DeleteDeveloper(string nameProject, string nickNameAutor, Account developer)
        {
            throw new NotImplementedException();
        }

        public Account GetAccount(string nickName)
        {
            using (var accountContext = new AccountContext())
            {
                return accountContext.Accounts
                    .Where(q => q.NickName == nickName)
                    .FirstOrDefault();
            }
        }

        public Project GetProject(string nameProject, string nickNameAutor)
        {
            using (var projectContext = new ProjectContext())
            {
                return projectContext.Projects
                    .Where(q => q.Name == nameProject && q.Developers.First().NickName == nickNameAutor)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <returns>Возвращает дату коммитов, версию и описание</returns>
        public List<CommitInformation> GetVersionList(Project project)
        {
            using (var projectContext = new ProjectContext())
            {
                return projectContext.Projects
                    .Where(q => q.Id == project.Id)
                    .FirstOrDefault()
                    .Commits
                    .Select(q => new CommitInformation(new Version(q.Number, q.Article), q.Date, q.Description))
                    .ToList();
            }
        }

        public Commit Pull(Project project, string version)
        {
            using (var commitContext = new CommitContext())
            {
                return commitContext.Commits
                    .Where(q => q.Number == version)
                    .FirstOrDefault();
            }
        }

        public bool ResetCommitVersion(string nameProject, string nickNameAutor, Version curr_version, Version new_version)
        {
            throw new NotImplementedException();
        }

        public Account SignIn(string login, string password)
        {
            var account = new Account();

            using (var accountContext = new AccountContext())
            {
                var result = accountContext.Accounts
                    .Where(q => q.Login == login && q.Password == password)
                    .FirstOrDefault();

                return result;
            }
        }

        public bool SignUp(Account account)
        {
            using (var accountContext = new AccountContext())
            {
                var accountExists = accountContext.Accounts
                    .Where(q => q.Login == account.Login || q.NickName == account.NickName)
                    .FirstOrDefault() != null;

                if (accountExists)
                    return false;

                accountContext.Accounts.Add(account);
                accountContext.SaveChanges();
            }
            return true;
        }
    }
}