using Microsoft.AspNetCore.Mvc;

namespace ROB.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
