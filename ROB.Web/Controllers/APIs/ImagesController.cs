using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ROB.Web.Controllers
{
    [Route("api/[controller]/{folder}")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSitePicture(string folder, string id)
        {
            var path = Resources.SiteImages + "/" + folder + "/" + id + ".gif";
            if (!System.IO.File.Exists(path))
            {
                Byte[] b = await Task.Run(() => System.IO.File.ReadAllBytes(@"wwwroot/images/placeHolder/questionMark.png")).ConfigureAwait(false);   // You can use your own method over here.         
                return File(b, "image/jpeg");
            }
            try
            {
                Byte[] b = await Task.Run(() => System.IO.File.ReadAllBytes(path)).ConfigureAwait(false);
                return File(b, "image/jpeg");
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,Developer")]
        public async Task<int> SetSitePicture(string folder, string id, IFormFile file)
        {
            var path = Resources.SiteImages + "/" + folder + "/";
            return await Resources.SetSitePicture(path, id, ".gif", file).ConfigureAwait(false);            
        }        
    }
}