using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitC
{
    public interface IGitController
    {
        Account SignIn(string login, string password);

        List<CommitInformation> GetVersionList(Project project); //return date version description
        Commit Pull(Project project, string version);
        Project GetProject(string nameProject, string nickNameAutor);
        Account GetAccount(string nickName);
        bool AddDeveloper(Project project, Account account);
        bool SignUp(Account account);
        bool Commit(Commit commit);
        bool DeleteDeveloper(string nameProject, string nickNameAutor, Account developer);
        bool ResetCommitVersion(string nameProject, string nickNameAutor, Version curr_version, Version new_version);
        bool CreateProject(Project project);
    }
}
