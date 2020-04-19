using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class ItemModel : ICharacterOwnable<CharacterSheet_Item_Link>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public double Cost { get; set; }
        public double ResellValue { get; set; }
        public int CategoryId { get; set; }
        public ItemCategoryModel Category { get; set; }
        public ICollection<CharacterSheet_Item_Link> CharacterSheets { get; set; } = new List<CharacterSheet_Item_Link>();
        public ICollection<Building_Item_Link> Buildings { get; set; } = new List<Building_Item_Link>();
        public ICollection<ItemPack_Item_Link> ItemPacks { get; set; } = new List<ItemPack_Item_Link>();
    }
}
