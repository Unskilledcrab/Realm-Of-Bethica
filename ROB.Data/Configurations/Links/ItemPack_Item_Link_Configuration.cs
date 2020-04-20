using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class ItemPack_Item_Link_Configuration : IEntityTypeConfiguration<ItemPack_Item_Link>
    {
        public void Configure(EntityTypeBuilder<ItemPack_Item_Link> builder)
        {
            builder
                .HasKey(link => new { link.ItemPackId, link.ItemId });

            builder
                .HasOne(link => link.ItemPack)
                .WithMany(classOne => classOne.Items)
                .HasForeignKey(link => link.ItemPackId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Item)
                .WithMany(classTwo => classTwo.ItemPacks)
                .HasForeignKey(link => link.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
