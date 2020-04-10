using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ROB.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammerTestController : ControllerBase
    {
        public class TestClass : IEquatable<TestClass>
        {
            public string Version { get; set; }
            public string Message { get; set; }
            public int Key { get; set; }
            public List<TestCharacter> Characters { get; set; }

            public bool Equals([AllowNull] TestClass other)
            {
                if (other == null) return false;

                return this.Characters.Equals(other.Characters) &&
                    this.Version.Equals(other.Version) &&
                    this.Message.Equals(other.Message) &&
                    this.Key.Equals(other.Key);
            }
        }

        public class TestCharacter : IEquatable<TestCharacter>
        {
            public string CharacterName { get; set; }
            public int Level { get; set; }

            public bool Equals([AllowNull] TestCharacter other)
            {
                if (other == null) return false;

                return this.CharacterName.Equals(other.CharacterName) &&
                    this.Level.Equals(other.Level);
            }
        }

        public static TestClass test { get; set; } = new TestClass
        {
            Version = "3.2.0.A",
            Message = "You're a wizard",
            Key = 6128,
            Characters = new List<TestCharacter>()
            {
                new TestCharacter{ CharacterName = "Harry", Level = 1000},
                new TestCharacter{ CharacterName = "Harmony", Level = 9000},
                new TestCharacter{ CharacterName = "Weasel", Level = 2000}
            }
        };

        [HttpGet]
        public ActionResult<TestClass> GetSecretCode()
        {
            return Ok(test);
        }

        [HttpGet("SubmitAnswer")]
        public ActionResult<string> TrySecretCode(TestClass attempt)
        {            
            if (test.Equals(attempt))
                return Ok("you will need this for the next part of the test...  <test-helper name='Titan' attribute='Tough'/>");
            else
                return NotFound("Try again :)");
        }
    }
}