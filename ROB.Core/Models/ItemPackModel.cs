using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class ItemPackModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ItemPack_Item_Link> Items { get; set; } = new List<ItemPack_Item_Link>();
    }
}