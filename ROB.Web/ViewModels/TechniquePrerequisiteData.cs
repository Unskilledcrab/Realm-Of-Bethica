using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.ViewModels
{
    public class TechniquePrerequisiteData
    {
        public int TechniqueId { get; set; }
        public string TechniqueName { get; set; }
        public bool IsPrerequisite { get; set; }
        public int TechniqueGroupId { get; set; }
    }
}
