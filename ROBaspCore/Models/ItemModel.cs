using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ROBaspCore.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Can not be more than 50 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        [Display(Name = "Cost in Copper (cp)")]
        public double Cost { get; set; }
        [Display(Name = "Resell Value")]
        public double ResellValue { get; set; }
        public int CategoryId { get; set; }
        public ItemCategoryModel Category { get; set; }
        public ICollection<CharacterSheet_Item_Link> CharacterSheets { get; set; } = new List<CharacterSheet_Item_Link>();
        public ICollection<Building_Item_Link> Buildings { get; set; } = new List<Building_Item_Link>();
        public ICollection<ItemPack_Item_Link> ItemPacks { get; set; } = new List<ItemPack_Item_Link>();
    }
}
