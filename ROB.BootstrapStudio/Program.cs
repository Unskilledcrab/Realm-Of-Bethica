using System;
using System.Diagnostics;


namespace ROB.BootstrapStudio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please type a comment for what you changed...");
            var input = Console.ReadLine();
            Console.WriteLine("Updating Project...");
            RunGit("pull");
            Console.WriteLine("Adding modified files...");
            RunGit("add *");
            Console.WriteLine("Committing modified files...");
            RunGit($"commit -m \"{input}\"");
            Console.WriteLine("Pushing modified files...");
            RunGit("push");
            Console.WriteLine("Complete... Press any key to close this window");
            Console.ReadKey();
        }

        static void RunGit(string arguments)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory.Replace("Advanced Scripts\\", "");
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.WorkingDirectory = baseDirectory;
            process.StartInfo.FileName = "git";
            process.Start();
            process.WaitForExit();
        }
    }
}
