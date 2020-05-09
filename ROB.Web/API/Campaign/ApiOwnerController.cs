using Microsoft.AspNetCore.Mvc;

namespace ROB.Web.API.Campaign
{
    /// <summary>
    /// Base class that will authenticate that the caller is the owner of the character sheet
    /// Uses the base route "api/{characterSheetId}/[controller]"
    /// </summary>
    [Route("api/{campaignId}/[controller]")]
    [ApiController]
    public abstract class ApiOwnerController : ControllerBase
    {
    }
}
