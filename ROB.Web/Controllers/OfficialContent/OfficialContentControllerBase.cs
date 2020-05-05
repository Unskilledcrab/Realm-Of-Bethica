using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.Controllers.OfficialContent
{
    /// <summary>
    /// You must have administrator or developer privledges to have access to this content
    /// </summary>
    [Authorize(Roles = "Administrator,Developer")]
    public abstract class OfficialContentControllerBase : Controller
    {
    }
}
