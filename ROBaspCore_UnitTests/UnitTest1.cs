using NUnit.Framework;
using ROBaspCore.Utilities;
using ROBaspCore.Models;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void SpellLevelCheck()
        {
            var spell = new SpellModel();
            spell.Area.ArcaneValue = 35;
            Assert.AreEqual(spell.SpellLevel, 4);
        }
    }
}