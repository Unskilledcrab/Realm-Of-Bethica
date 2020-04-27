using System;
using System.Diagnostics;

namespace ROB.BootstrapStudio.Initalizer
{
    class Program
    {
        /// <summary>
        /// Bootstrap studio by default opens up the console hidden.. this is the only way to have the 
        /// app open up a console window
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args.Length == 0) args = new string[1] { "test" };
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            process.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "ROB.BootstrapStudio.exe";
            process.StartInfo.Arguments = args[0]; // Studio always passes one arg
            process.Start();
        }
    }
}
