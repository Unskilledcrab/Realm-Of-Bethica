using System;
using System.IO;

namespace ROB.BootstrapStudio
{
    class Program
    {
        static void Main(string[] args)
        {
            string exportPath = args[0];
            RecursivelyFindAndReplaceInDirectory(exportPath);
        }

        private static void RecursivelyFindAndReplaceInDirectory(string directoryPath)
        {
            foreach (var directory in Directory.GetDirectories(directoryPath))
            {
                foreach (var file in Directory.GetFiles(directory))
                {
                    string text = File.ReadAllText(file);

                    // Replace CSS Paths
                    text = text.Replace("url(../assets/img/", "url(../images/_BStudio/");
                    text = text.Replace("url(../../assets/img/", "url(../../images/_BStudio/");
                    text = text.Replace("url(../../../assets/img/", "url(../../../images/_BStudio/");
                    text = text.Replace("url(../../../../assets/img/", "url(../../../../images/_BStudio/");

                    // Replace all view paths
                    text = text.Replace(@"src=""../assets/img/", @"src=""~/images/_BStudio/");
                    text = text.Replace(@"src=""../../assets/img/", @"src=""~/images/_BStudio/");
                    text = text.Replace(@"src=""../../../assets/img/", @"src=""~/images/_BStudio/");
                    text = text.Replace(@"src=""../../../../assets/img/", @"src=""~/images/_BStudio/");
                    text = text.Replace(@"src=""../../../../../assets/img/", @"src=""~/images/_BStudio/");

                    text = text.Replace(@"src=""../assets/js/", @"src=""~/js/_BStudio/");
                    text = text.Replace(@"src=""../../assets/js/", @"src=""~/js/_BStudio/");
                    text = text.Replace(@"src=""../../../assets/js/", @"src=""~/js/_BStudio/");
                    text = text.Replace(@"src=""../../../../assets/js/", @"src=""~/js/_BStudio/");

                    text = text.Replace(@"src=""../assets/css/", @"src=""~/css/_BStudio/");
                    text = text.Replace(@"src=""../../assets/css/", @"src=""~/css/_BStudio/");
                    text = text.Replace(@"src=""../../../assets/css/", @"src=""~/css/_BStudio/");
                    text = text.Replace(@"src=""../../../../assets/css/", @"src=""~/css/_BStudio/");

                    // Seperate out their non-sense formatting
                    text = text.Replace("><", ">\r\n<");

                    File.WriteAllText(file, text);
                }
                RecursivelyFindAndReplaceInDirectory(directory);
            }
        }
    }
}
