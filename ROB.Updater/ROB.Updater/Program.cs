using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace ROB.Updater
{
    class Program
    {
        private static readonly string keyROBPath = "ROBProjectPath";
        private static readonly string keyStudioPath = "StudioProjectPath";

        private static readonly string cssPath = "css\\_BStudio";
        private static readonly string jsPath = "js\\_BStudio";
        private static readonly string imagesPath = "images\\_BStudio";
        
        private static readonly string studioCSSPath = "Source\\assets\\css";
        private static readonly string studioJSPath = "Source\\assets\\js";
        private static readonly string studioImagesPath = "Source\\assets\\img";

        static void Main(string[] args)
        {
            var ROBPath = ConfigurationManager.AppSettings[keyROBPath];
            var studioPath = ConfigurationManager.AppSettings[keyStudioPath];
            if (ROBPath == null)
            {
                SetupProjectPath();
                ROBPath = ConfigurationManager.AppSettings[keyROBPath];
            }
            if (studioPath == null)
            {
                SetupStudioPath();
                studioPath = ConfigurationManager.AppSettings[keyStudioPath];
            }

            Console.WriteLine("Would you like to get the updated project? [Y/N]");
            Console.WriteLine("NOTE: This will pull the latest changes from the rob-bootstrap repo AND revert any formatting or changes made locally.");
            var input = Console.ReadLine();
            if (input.ToUpper() == "Y")
            {
                Console.WriteLine("Resetting Project...");
                RunGit("reset", studioPath);
                Console.WriteLine("Reverting formatting...");
                RunGit("checkout .", studioPath);
                Console.WriteLine("Pulling in changes...");
                RunGit("pull", studioPath);
            }

            Console.WriteLine("Would you like to format the bootstrap studio directory files? [Y/N]");
            input = Console.ReadLine();
            if (input.ToUpper() == "Y")
            {
                var formatter = new Formatter(studioPath);
                formatter.FormatBootstrapStudioFiles(studioPath);
                Console.WriteLine("Formatting Completed");
            }

            var ROBcssPath = Path.Combine(ROBPath, cssPath);
            var ROBjsPath = Path.Combine(ROBPath, jsPath);
            var ROBimagesPath = Path.Combine(ROBPath, imagesPath);

            var StudiocssPath = Path.Combine(studioPath, studioCSSPath);
            var StudiojsPath = Path.Combine(studioPath, studioJSPath);
            var StudioimagesPath = Path.Combine(studioPath, studioImagesPath);


            Console.WriteLine("Would you like to delete old files? [Y/N]");
            Console.WriteLine("NOTE: This will delete all files in _BStudio folder in the CSS, js, images folders.");
            input = Console.ReadLine();
            if (input.ToUpper() == "Y")
            {
                DeleteDirectory(ROBcssPath);
                DeleteDirectory(ROBjsPath);
                DeleteDirectory(ROBimagesPath);
                Console.WriteLine("Deletion Completed");
            }

            Console.WriteLine("Would you like to copy files into ROB.Web? [Y/N]");
            Console.WriteLine("NOTE: This will copy all files from the rob-bootstrap project into the _BStudio folders in the CSS, js, images folders.");
            input = Console.ReadLine();
            if (input.ToUpper() == "Y")
            {
                Copy(StudiocssPath, ROBcssPath);
                Copy(StudiojsPath, ROBjsPath);
                Copy(StudioimagesPath, ROBimagesPath);
                Console.WriteLine("Copy Completed");
            }
        }

        static void RunGit(string arguments, string bootstrapStudioPath)
        {
            var baseDirectory = bootstrapStudioPath.Replace("Exports", "");
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.WorkingDirectory = baseDirectory;
            process.StartInfo.FileName = "git";
            process.Start();
            process.WaitForExit();
        }

        private static void Copy(string sourceDirectory, string targetDirectory)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);
 
            CopyAll(diSource, diTarget);
        }

        private static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);
 
            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }
 
            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        static void DeleteDirectory(string directoryPath)
        {
            string path = directoryPath;

		    DirectoryInfo directory = new DirectoryInfo(path);

            try
            {
                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
		
		    foreach (DirectoryInfo dir in directory.GetDirectories())
		    {
			    dir.Delete(true);
		    }
        }

        static void SetupProjectPath()
        {
            Console.WriteLine("Please put in the path to the wwwroot of the ROB.Web Project.");
            var input = Console.ReadLine();
            if (!input.EndsWith("ROB.Web\\wwwroot"))
            {
                Console.WriteLine("This path is incorrect. Please enter a path that ends with 'ROB.Web\\wwwroot'");
                SetupProjectPath();
            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(keyROBPath);
            config.AppSettings.Settings.Add(keyROBPath, input);
            config.Save(ConfigurationSaveMode.Minimal);

            Console.WriteLine("Path has been successfully configured, you will have to change this setting in ROB.Updater.dll.config if this path changes.");
        }

        static void SetupStudioPath()
        {
            Console.WriteLine("Please put in the path to rob-bootstrap project exports folder.");
            var input = Console.ReadLine();
            if (!input.EndsWith("rob-bootstrap\\Exports"))
            {
                Console.WriteLine("This path is incorrect. Please enter a path that ends with 'rob-bootstrap\\Exports'");
                SetupStudioPath();
            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(keyStudioPath);
            config.AppSettings.Settings.Add(keyStudioPath, input);
            config.Save(ConfigurationSaveMode.Minimal);

            Console.WriteLine("Path has been successfully configured, you will have to change this setting in ROB.Updater.dll.config if this path changes.");
        }
    }
}
