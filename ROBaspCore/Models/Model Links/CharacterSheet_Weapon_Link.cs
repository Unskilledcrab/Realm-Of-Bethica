using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROBaspCore.Models
{
    public class CharacterSheet_Weapon_Link
    {
        public int? CharacterSheetId { get; set; }
        public CharacterSheetModel CharacterSheet { get; set; }
        public int? WeaponId { get; set; }
        public WeaponModel Weapon { get; set; }
    }
}
