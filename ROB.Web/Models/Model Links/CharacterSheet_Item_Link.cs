using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.Models
{
    public class CharacterSheet_Item_Link
    {
        public int CharacterSheetId { get; set; }
        public CharacterSheetModel CharacterSheet { get; set; }
        public int ItemId { get; set; }
        public ItemModel Item { get; set; }
    }
}
