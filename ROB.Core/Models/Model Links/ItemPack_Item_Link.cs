namespace ROB.Core.Models
{
    public class ItemPack_Item_Link
    {
        public int ItemPackId { get; set; }
        public ItemPackModel ItemPack { get; set; }
        public int ItemId { get; set; }
        public ItemModel Item { get; set; }
    }
}
