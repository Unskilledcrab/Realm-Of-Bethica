using System;
using System.Configuration;
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

            Formatter.FormatBootstrapStudioFiles(studioPath);

            var ROBcssPath = Path.Combine(ROBPath, cssPath);
            var ROBjsPath = Path.Combine(ROBPath, jsPath);
            var ROBimagesPath = Path.Combine(ROBPath, imagesPath);

            var StudiocssPath = Path.Combine(studioPath, studioCSSPath);
            var StudiojsPath = Path.Combine(studioPath, studioJSPath);
            var StudioimagesPath = Path.Combine(studioPath, studioImagesPath);

            DeleteDirectory(ROBcssPath);
            DeleteDirectory(ROBjsPath);
            DeleteDirectory(ROBimagesPath);

            Copy(StudiocssPath, ROBcssPath);
            Copy(StudiojsPath, ROBjsPath);
            Copy(StudioimagesPath, ROBimagesPath);
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
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
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

		    foreach (FileInfo file in directory.GetFiles())
		    {
			    file.Delete();
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
