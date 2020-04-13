using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.ViewModels
{
    public class PregenAssignedTechniquesData
    {
        public int TechniqueId { get; set; }
        public string TechniqueName { get; set; }
        public bool IsAssigned { get; set; }
    }
}
