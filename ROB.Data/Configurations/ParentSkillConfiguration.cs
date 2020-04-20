using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class ParentSkillConfiguration : IEntityTypeConfiguration<ParentSkillModel>
    {
        public void Configure(EntityTypeBuilder<ParentSkillModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(75);


            builder
                .HasMany(p => p.ChildSkills)
                .WithOne(c => c.ParentSkill)
                .HasForeignKey(c => c.ParentSkillId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }

}
