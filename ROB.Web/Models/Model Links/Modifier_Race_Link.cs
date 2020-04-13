using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.Models
{
    public class Modifier_Race_Link
    {
        public int ModifierId { get; set; }
        public ModifierModel Modifier { get; set; }
        public int RaceId { get; set; }
        public RaceModel Race { get; set; }
    }
}
