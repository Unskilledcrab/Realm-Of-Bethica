using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.Models
{
    public class CharacterSheet_Spell_Link
    {
        public int? CharacterSheetId { get; set; }
        public CharacterSheetModel CharacterSheet { get; set; }
        public int? SpellId { get; set; }
        public SpellModel Spell { get; set; }
    }
}
