using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class ArmorConfiguration : IEntityTypeConfiguration<ArmorModel>
    {
        public void Configure(EntityTypeBuilder<ArmorModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(100);
        }
    }


    public class ArcanePowerAttributeConfiguration : IEntityTypeConfiguration<ArcanePowerAttributeModel>
    {
        public void Configure(EntityTypeBuilder<ArcanePowerAttributeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(100);
            
            builder
                .Property(b => b.Type)
                .HasMaxLength(100);
            
            builder
                .Property(b => b.Effects)
                .HasMaxLength(200);
        }
    }

    public class ArcaneSphereConfiguration : IEntityTypeConfiguration<ArcaneSphereModel>
    {
        public void Configure(EntityTypeBuilder<ArcaneSphereModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(100);
        }
    }

    public class ArcaneSubgroupConfiguration : IEntityTypeConfiguration<ArcaneSubgroupModel>
    {
        public void Configure(EntityTypeBuilder<ArcaneSubgroupModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(100);
        }
    }

    public class ArmorRestorationConfiguration : IEntityTypeConfiguration<ArmorRestorationModel>
    {
        public void Configure(EntityTypeBuilder<ArmorRestorationModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.ArmorStyle)
                .HasMaxLength(100);
        }
    }

    public class ArmorRestrictionConfiguration : IEntityTypeConfiguration<ArmorRestrictionModel>
    {
        public void Configure(EntityTypeBuilder<ArmorRestrictionModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(100);
        }
    }

    public class AttributeConfiguration : IEntityTypeConfiguration<AttributeModel>
    {
        public void Configure(EntityTypeBuilder<AttributeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

        }
    }

    public class BuildingConfiguration : IEntityTypeConfiguration<BuildingModel>
    {
        public void Configure(EntityTypeBuilder<BuildingModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(100);

        }
    }

    public class BaseConfiguration<TModel> : IEntityTypeConfiguration<TModel> where TModel : class
    {
        public void Configure(EntityTypeBuilder<TModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

        }
    }

}
