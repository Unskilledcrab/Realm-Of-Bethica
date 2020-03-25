using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ROBaspCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammerTestController : ControllerBase
    {
        public class TestClass
        {
            public string Version { get; set; }
            public string Message { get; set; }
            public int Key { get; set; }
        }

        [HttpGet]
        public string GetSecretCode(TestClass test)
        {
            if (test.Version == "1.2.3" && test.Message == "I will pass" && test.Key == 32)
                return "Secrets Secrets Are No Fun";
            else
                return "Try again :)";
        }     
    }
}