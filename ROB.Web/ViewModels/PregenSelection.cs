using ROB.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.ViewModels
{
    public class PregenSelection
    {
        public int CharacterSheetId { get; set; }
        public ICollection<PregenProfessionArchetypeModel> Pregens { get; set; } = new List<PregenProfessionArchetypeModel>();
    }
}
