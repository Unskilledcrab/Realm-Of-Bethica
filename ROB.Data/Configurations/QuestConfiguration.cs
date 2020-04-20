using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class QuestConfiguration : IEntityTypeConfiguration<QuestModel>
    {
        public void Configure(EntityTypeBuilder<QuestModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Title)
                .HasMaxLength(75);
        }
    }

}
