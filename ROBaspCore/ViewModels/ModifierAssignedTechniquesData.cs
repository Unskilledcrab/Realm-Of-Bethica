using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROBaspCore.ViewModels
{
    public class ModifierAssignedTechniquesData
    {
        public int TechniqueId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAssigned { get; set; }
    }
}
