using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class QuestTagConfiguration : IEntityTypeConfiguration<QuestTagModel>
    {
        public void Configure(EntityTypeBuilder<QuestTagModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Title)
                .HasMaxLength(50);
        }
    }

}
