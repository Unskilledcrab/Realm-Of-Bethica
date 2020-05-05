using Microsoft.AspNetCore.Mvc;
using ROB.Web.Attributes;

namespace ROB.Web.API
{
    /// <summary>
    /// Base class that will authenticate that the caller is the owner of the character sheet
    /// Uses the base route "api/{characterSheetId}/[controller]"
    /// </summary>
    [ServiceFilter(typeof(AuthorizeSheetOwnerAttribute))]
    [Route("api/{characterSheetId}/[controller]")]
    [ApiController]
    public abstract class ApiOwnerControllerBase : ControllerBase
    {
    }
}
