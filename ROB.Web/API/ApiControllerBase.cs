using Microsoft.AspNetCore.Mvc;
using ROB.Web.Data.Migrations;
using System;
using System.Collections.Generic;

namespace ROB.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}


