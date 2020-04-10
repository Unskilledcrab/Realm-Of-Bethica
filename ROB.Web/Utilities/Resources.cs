using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ROB.Web
{
    public static class Resources
    {
        /// <summary>
        /// This is the base path that all static files should reference in 
        /// this project
        /// </summary>
        public static string UBUnlimitedBasePath { get; } = "../static/UBUnlimited/";
        public static string SiteImages { get; set; } = UBUnlimitedBasePath + "_site/images/";
        public static string RaceImagesPath { get; } = SiteImages + "race/";
        public static string PregenImagesPath { get; } = SiteImages + "pregen/";
        /// <summary>
        /// Use to set a picture on the site
        /// </summary>
        /// <param name="staticPath">Use the resource </param>
        /// <param name="id"></param>
        /// <param name="ext"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static async Task<int> SetSitePicture(string staticPath, string id, string ext, IFormFile file)
        {            
            try
            {
                if (file != null && file.Length > 0)
                {
                    var path = staticPath + "/" + id + ext;
                    if (System.IO.File.Exists(path)) { System.IO.File.Delete(path); } // if picture already exists delete it
                    using (var stream = new FileStream(path, FileMode.Create)) // upload new picture
                    {
                        await file.CopyToAsync(stream).ConfigureAwait(false);
                    }
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
        public static int DeleteSitePicture(string staticPath, string id, string ext)
        {
            try
            {
                var path = staticPath + "/" + id + ext;
                if (System.IO.File.Exists(path)) { System.IO.File.Delete(path); }
                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
