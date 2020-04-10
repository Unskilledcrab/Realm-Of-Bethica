using ROB.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.ViewModels
{
    public class RaceSelection
    {
        public int CharacterSheetId { get; set; }
        public ICollection<RaceModel> Races { get; set; } = new List<RaceModel>();
    }
}
