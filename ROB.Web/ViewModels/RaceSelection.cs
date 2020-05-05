using ROB.Web.Models;
using System.Collections.Generic;

namespace ROB.Web.ViewModels
{
    public class RaceSelection
    {
        public int CharacterSheetId { get; set; }
        public ICollection<RaceModel> Races { get; set; } = new List<RaceModel>();
    }
}
