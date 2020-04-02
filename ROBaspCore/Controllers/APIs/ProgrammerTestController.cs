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

        public static TestClass test { get; set; } = new TestClass
        {
            Version = "3.2.0.A",
            Message = "<test-helper name='Titan' attribute='Tough'/>",
            Key = 6128
        };

        [HttpGet]
        public ActionResult<TestClass> GetSecretCode()
        {
            return Ok(test);
        }

        [HttpGet("SubmitAnswer")]
        public ActionResult<string> TrySecretCode(TestClass attempt)
        {
            if (attempt.Version == test.Version && attempt.Message == test.Message && attempt.Key == test.Key)
                return Ok("Secrets Secrets Are No Fun");
            else
                return NotFound("Try again :)");
        }
    }
}