using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ROB.Updater
{
    class Formatter
    {
        public List<string> TopLevelDirectories = new List<string>();
        private string currentDirectory;
        private string prefix;

        public Formatter(string directoryPath)
        {
            foreach (var directory in Directory.GetDirectories(directoryPath))
            {
                TopLevelDirectories.Add(new DirectoryInfo(directory).Name);
            }
        }

        public void FormatBootstrapStudioFiles(string directoryPath)
        {
            foreach (var directory in Directory.GetDirectories(directoryPath))
            {
                var directoryName = new DirectoryInfo(directory).Name;
                if (TopLevelDirectories.Contains(directoryName))
                {
                    currentDirectory = directoryName + "/";
                    prefix = "../";
                }
                if (directoryName == "Source")
                { 
                    // If it is source it does not need a prefix or sub folder path name
                    currentDirectory = "";
                    prefix = "";
                }
                foreach (var file in Directory.GetFiles(directory))
                {
                    if (file.EndsWith(".html"))
                        ReplaceHTMLFiles(file);
                    if (file.EndsWith(".css"))
                        ReplaceCSSFiles(file);
                    if (file.EndsWith(".js"))
                        ReplaceJsFiles(file);
                }
                FormatBootstrapStudioFiles(directory);
            }
        }

        private void ReplaceJsFiles(string file)
        {
            //string text = File.ReadAllText(file);

            //File.WriteAllText(file, text);
        }

        private void ReplaceCSSFiles(string file)
        {
            string text = File.ReadAllText(file);

            // Replace CSS Paths
            text = text.Replace("assets/img/", prefix + "images/_BStudio/" + currentDirectory);

            File.WriteAllText(file, text);
        }

        private void ReplaceHTMLFiles(string file)
        {
            string text = File.ReadAllText(file);

            var imagePath = $"src=\"~/images/_BStudio/{currentDirectory}";
            var jsPath = $"src=\"~/js/_BStudio/{currentDirectory}";
            var cssPath = $"src=\"~/css/_BStudio/{currentDirectory}";

            // Replace all view paths
            text = text.Replace(@"src=""assets/img/", imagePath);
            text = text.Replace(@"src=""../assets/img/", imagePath);
            text = text.Replace(@"src=""../../assets/img/", imagePath);
            text = text.Replace(@"src=""../../../assets/img/", imagePath);
            text = text.Replace(@"src=""../../../../assets/img/", imagePath);
            text = text.Replace(@"src=""../../../../../assets/img/", imagePath);

            text = text.Replace(@"src=""assets/js/", jsPath);
            text = text.Replace(@"src=""../assets/js/", jsPath);
            text = text.Replace(@"src=""../../assets/js/", jsPath);
            text = text.Replace(@"src=""../../../assets/js/", jsPath);
            text = text.Replace(@"src=""../../../../assets/js/", jsPath);

            text = text.Replace(@"src=""assets/css/", cssPath);
            text = text.Replace(@"src=""../assets/css/", cssPath);
            text = text.Replace(@"src=""../../assets/css/", cssPath);
            text = text.Replace(@"src=""../../../assets/css/", cssPath);
            text = text.Replace(@"src=""../../../../assets/css/", cssPath);

            // Seperate out their non-sense formatting and tag what needs to be updated still
            text = text.Replace("><", ">\r\n<");
            text = text.Replace("<a ", "\r\n<!-- UPDATE REQUIRED (LINK) -->\r\n<a ");

            File.WriteAllText(file, text);
        }
    }
}
