using ROB.Web.Models;
using System.Collections.Generic;

namespace ROB.Web.ViewModels
{
    public class PregenSelection
    {
        public int CharacterSheetId { get; set; }
        public ICollection<PregenProfessionArchetypeModel> Pregens { get; set; } = new List<PregenProfessionArchetypeModel>();
    }
}
