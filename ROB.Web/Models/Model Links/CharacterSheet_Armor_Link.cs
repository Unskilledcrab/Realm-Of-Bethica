using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.Models
{
    public class CharacterSheet_Armor_Link
    {
        public int CharacterSheetId { get; set; }
        public CharacterSheetModel CharacterSheet { get; set; }
        public int ArmorId { get; set; }
        public ArmorModel Armor { get; set; }
    }
}
