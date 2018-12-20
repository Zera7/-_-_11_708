using System;
using System.Collections.Generic;
using System.IO;
using GitC;
using AVC;
using AVM;
namespace git
{
    public class Cmd
    {
        private GitController controller = new GitController();
        private Account account = null;
        private string getArgBetween(string leftBorder,string rightBorder,string doner)
        {
            return doner.Substring(doner.IndexOf(leftBorder) + 1, doner.LastIndexOf(rightBorder) - doner.IndexOf(leftBorder) - 1);
        }
        public static void ClearCommand(ref string Command, char rubbish = ' ')
        {
            while (true)
            {
                int indexrub = Command.IndexOf(rubbish);
                if (indexrub == -1)
                    return;
                Command = Command.Remove(indexrub, 1);
            }

        }
        public static string[] GetArguments(string instruction)
        {
            List<string> result = new List<string>();
            instruction = instruction.Substring(instruction.IndexOf(' ') + 1);
            int indexcomma;
            string nextcommand = "";
            while (true)
            {
                indexcomma = instruction.IndexOf(' ');
                if (indexcomma == -1)
                    break;
                nextcommand = instruction.Substring(0, indexcomma);
                ClearCommand(ref nextcommand);
                result.Add(nextcommand);
                instruction = instruction.Substring(indexcomma + 1);
            }
            ClearCommand(ref instruction);
            result.Add(instruction);
            return result.ToArray();
        }
        public string GetStringFromArray(string[] array, char separator)
        {
            var builder = new System.Text.StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                builder.Append(array);
                if (i < array.Length - 1)
                    builder.Append(separator);
            }
            return builder.ToString();
        }
        private void Compile(string[] args)
        {
            List<string> code = new List<string>();
            StreamReader reader = new StreamReader(args[0]);
            while (!reader.EndOfStream)
                code.Add(reader.ReadLine());
            File.WriteAllBytes(args[1], AVComplier.Compile(code.ToArray()));
        }
        private void Run(string[] args)
        {
            AssemblerVirtualMachine machine = new AssemblerVirtualMachine();
            machine.Run(File.ReadAllBytes(args[0]));
            Console.WriteLine("");
        }
        private void ShowProjectList()
        {
            for(int i = 0; i < account.Projects.Count;i++)
                Console.WriteLine(account.Projects[i].Name);
        }
        private void Show(string[] args)
        {
            if (args[0] == "project" && args[1] == "list")
                ShowProjectList();
        }
        public void SignIn()
        {
            string login, password;
            Console.Write("login : ");
            login = Console.ReadLine();
            Console.Write("password : ");
            password = Console.ReadLine();
            account = controller.SignIn(login, password);
            if(account!=null)
                Console.WriteLine("Logined");
        }
        public void SignUp()
        {
            string nick, login, password, checkpassword, email;
            Console.Write("NickName : ");
            nick = Console.ReadLine();
            Console.Write("Login : ");
            login = Console.ReadLine();
            Console.Write("Password : ");
            password = Console.ReadLine();
            Console.Write("Check your password : ");
            checkpassword = Console.ReadLine();
            Console.Write("Email : ");
            email = Console.ReadLine();
            if (password == checkpassword)
            {
                if(controller.SignUp(new Account(nick, login, password, email, 0, new List<Commit>(), new List<Project>())))
                    Console.WriteLine("Registered");
                Console.WriteLine("This account already exist");
                return;
            }
            Console.WriteLine("not correct check password");
            SignUp();
        }
        public void Commit(string[] args)
        {
            string description = "", projectName = "", projectAutorNick = "", version = "";
            List<string> code = new List<string>();
            DateTime time = DateTime.Now;
            for(int i = 0;i<args.Length;i++)
            {
                if(args[i].Length>=4)
                {
                    if(args[i][0] == '-' && args[i][1] == 'm')
                    {
                        description = getArgBetween("\"", "\"", args[i]);
                        Console.WriteLine(description);
                    }
                    if (args[i][0] == '-' && args[i][1] == 'v')
                    {
                        version = getArgBetween("\"", "\"", args[i]);
                        Console.WriteLine(version);
                    }
                    if (args[i][0] == '-' && args[i][1] == 'p')
                        projectName = getArgBetween("\"", "\"", args[i]);
                    if (args[i][0] == '-' && args[i][1] == 'a')
                        projectAutorNick = getArgBetween("\"", "\"", args[i]);
                    continue;
                }
                using (StreamReader reader = new StreamReader(args[i]))
                {
                    while(reader.EndOfStream)
                        code.Add(reader.ReadLine());
                }
            }
            controller.Commit(new GitC.Commit(GetStringFromArray(code.ToArray(), '^'),account,description,DateTime.Now,version,controller.GetProject(projectName,projectAutorNick)));
        }
        private void Pull()
        {
            string nameProject = "", nickNameAutor ="", version="";
            Console.Write("Project name : ");
            nameProject = Console.ReadLine();
            Console.Write("Autor nick : ");
            nickNameAutor = Console.ReadLine();
            Console.Write("Version : ");
            version = Console.ReadLine();
            GitC.Commit commit = controller.Pull(controller.GetProject(nameProject, nickNameAutor), version);
            string filename = commit.Project.ToString() + "_" + commit.Number + "_" + commit.Date + ".commit";
            File.WriteAllLines(filename, commit.Code.Split('^'));
        }
        private void CreateProject()
        {
            string name, description;
            Console.Write("Project name : ");
            name = Console.ReadLine();
            Console.Write("Description : ");
            description = Console.ReadLine();
            List<Account> devs = new List<Account>();
            devs.Add(account);
            if(controller.CreateProject(new Project(name, devs, new List<Commit>(), description)))
                Console.WriteLine("Project created");
            else
                Console.WriteLine("Already exist, try again");
        }
        public void Execute(string command)
        {
            string[] args = GetArguments(command);
            if (command.IndexOf(' ') >= 0)
                command = command.Substring(0, command.IndexOf(' '));
            if (command == "signin")
                SignIn();
            if (command == "signup")
                SignUp();
            if (command == "compile")
                Compile(args);
            if (command == "run")
                Run(args);
            if (command == "createproj")
                CreateProject();
            if (command == "show")
                Show(args);
            if (command == "pull")
                Pull();
            if (command == "commit")
                Commit(args);
        }
    }
    class main
    {
        
        static void Main(string[] args)
        {
            Cmd cmd = new Cmd();
            string command = "";
            while(command != "exit")
            {
                command = Console.ReadLine();
                cmd.Execute(command);
            }
            DateTime date1 = new DateTime(2008, 5, 1, 8, 30, 52);
            Console.WriteLine(date1.ToString());
        }
    }
}
