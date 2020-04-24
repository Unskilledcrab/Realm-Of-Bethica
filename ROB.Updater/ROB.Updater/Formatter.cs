using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ROB.Updater
{
    class Formatter
    {
        public static void FormatBootstrapStudioFiles(string directoryPath)
        {
            foreach (var directory in Directory.GetDirectories(directoryPath))
            {
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

        private static void ReplaceJsFiles(string file)
        {
            string text = File.ReadAllText(file);

            File.WriteAllText(file, text);
        }

        private static void ReplaceCSSFiles(string file)
        {
            string text = File.ReadAllText(file);

            // Replace CSS Paths
            text = text.Replace("url(../assets/img/", "url(../images/_BStudio/");
            text = text.Replace("url(../../assets/img/", "url(../../images/_BStudio/");
            text = text.Replace("url(../../../assets/img/", "url(../../../images/_BStudio/");
            text = text.Replace("url(../../../../assets/img/", "url(../../../../images/_BStudio/");

            text = text.Replace("url(\"../assets/img/", "url(\"../images/_BStudio/");
            text = text.Replace("url(\"../../assets/img/", "url(\"../../images/_BStudio/");
            text = text.Replace("url(\"../../../assets/img/", "url(\"../../../images/_BStudio/");
            text = text.Replace("url(\"../../../../assets/img/", "url(\"../../../../images/_BStudio/");

            File.WriteAllText(file, text);
        }

        private static void ReplaceHTMLFiles(string file)
        {
            string text = File.ReadAllText(file);

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
            text = text.Replace("<a ", "\r\n<!-- UPDATE REQUIRED (LINK) -->\r\n<a ");

            File.WriteAllText(file, text);
        }
    }
}
