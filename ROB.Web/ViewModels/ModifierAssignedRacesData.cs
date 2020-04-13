using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.ViewModels
{
    public class ModifierAssignedRacesData
    {
        public int RaceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAssigned { get; set; }
    }
}
