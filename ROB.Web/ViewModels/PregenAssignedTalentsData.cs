using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.ViewModels
{
    public class PregenAssignedTalentsData
    {
        public int TalentId { get; set; }
        public string TalentName { get; set; }
        public bool IsAssigned { get; set; }
    }
}
