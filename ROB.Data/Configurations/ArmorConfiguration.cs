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

            builder
                .HasMany(p => p.Spells)
                .WithOne(c => c.ArcaneSphere)
                .HasForeignKey(c => c.ArcaneSphereId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasMany(p => p.ArcaneSubgroups)
                .WithOne(c => c.ArcaneSphere)
                .HasForeignKey(c => c.ArcaneSphereId)
                .OnDelete(DeleteBehavior.ClientSetNull);
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

    public class BuildingRatingConfiguration : IEntityTypeConfiguration<BuildingRatingModel>
    {
        public void Configure(EntityTypeBuilder<BuildingRatingModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Rating)
                .HasMaxLength(50);
        }
    }

    public class BuildingSpecialtyConfiguration : IEntityTypeConfiguration<BuildingSpecialtyModel>
    {
        public void Configure(EntityTypeBuilder<BuildingSpecialtyModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Specialty)
                .HasMaxLength(50);
        }
    }

    public class BuildingTypeConfiguration : IEntityTypeConfiguration<BuildingTypeModel>
    {
        public void Configure(EntityTypeBuilder<BuildingTypeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(75);
        }
    }

    public class CharacterAttributeConfiguration : IEntityTypeConfiguration<CharacterAttributeModel>
    {
        public void Configure(EntityTypeBuilder<CharacterAttributeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

        }
    }

    public class CharacterSheetConfiguration : IEntityTypeConfiguration<CharacterSheetModel>
    {
        public void Configure(EntityTypeBuilder<CharacterSheetModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .Property(b => b.Gender)
                .HasMaxLength(75);

            builder
                .Property(b => b.Faith)
                .HasMaxLength(1500);

            builder
                .Property(b => b.EyeColor)
                .HasMaxLength(45);

            builder
                .Property(b => b.HairColor)
                .HasMaxLength(45);

            builder
                .Property(b => b.SkinColor)
                .HasMaxLength(45);
        }
    }

    public class ChildSkillConfiguration : IEntityTypeConfiguration<ChildSkillModel>
    {
        public void Configure(EntityTypeBuilder<ChildSkillModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(150);
        }
    }

    public class DamageTypeConfiguration : IEntityTypeConfiguration<DamageTypeModel>
    {
        public void Configure(EntityTypeBuilder<DamageTypeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(75);
        }
    }

    public class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategoryModel>
    {
        public void Configure(EntityTypeBuilder<ItemCategoryModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(75);
        }
    }

    public class ItemConfiguration : IEntityTypeConfiguration<ItemModel>
    {
        public void Configure(EntityTypeBuilder<ItemModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(150);
        }
    }

    public class ItemPackConfiguration : IEntityTypeConfiguration<ItemPackModel>
    {
        public void Configure(EntityTypeBuilder<ItemPackModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

        }
    }

    public class LanguageGroupTypeConfiguration : IEntityTypeConfiguration<LanguageGroupTypeModel>
    {
        public void Configure(EntityTypeBuilder<LanguageGroupTypeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.LanguageType)
                .HasMaxLength(75);
        }
    }

    public class LanguageConfiguration : IEntityTypeConfiguration<LanguageModel>
    {
        public void Configure(EntityTypeBuilder<LanguageModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.LanguageName)
                .HasMaxLength(75);

            builder
                .Property(b => b.TypeName)
                .HasMaxLength(75);
        }
    }

    public class ModifierConfiguration : IEntityTypeConfiguration<ModifierModel>
    {
        public void Configure(EntityTypeBuilder<ModifierModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

        }
    }

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

    public class PoisonClassConfiguration : IEntityTypeConfiguration<PoisonClassModel>
    {
        public void Configure(EntityTypeBuilder<PoisonClassModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(75);
        }
    }

    public class PoisonConfiguration : IEntityTypeConfiguration<PoisonModel>
    {
        public void Configure(EntityTypeBuilder<PoisonModel> builder)
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
                .Property(b => b.Effect)
                .HasMaxLength(75);
        }
    }

    public class PoisonTypeConfiguration : IEntityTypeConfiguration<PoisonTypeModel>
    {
        public void Configure(EntityTypeBuilder<PoisonTypeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(75);
        }
    }

    public class PregenProfessionArchetypeConfiguration : IEntityTypeConfiguration<PregenProfessionArchetypeModel>
    {
        public void Configure(EntityTypeBuilder<PregenProfessionArchetypeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(150);
        }
    }

    public class QuestGroupConfiguration : IEntityTypeConfiguration<QuestGroupModel>
    {
        public void Configure(EntityTypeBuilder<QuestGroupModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Title)
                .HasMaxLength(75);


            builder
                .HasMany(p => p.Quests)
                .WithOne(c => c.QuestGroup)
                .HasForeignKey(c => c.QuestGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }

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

    public class QuestRatingConfiguration : IEntityTypeConfiguration<QuestRatingModel>
    {
        public void Configure(EntityTypeBuilder<QuestRatingModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Rating)
                .HasMaxLength(50);


            builder
                .HasMany(p => p.Quests)
                .WithOne(c => c.DifficultyRating)
                .HasForeignKey(c => c.DifficultyRatingId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }

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

    public class RaceConfiguration : IEntityTypeConfiguration<RaceModel>
    {
        public void Configure(EntityTypeBuilder<RaceModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.DescriptionBrief)
                .HasMaxLength(150);

            builder
                .Property(b => b.HeightInches)
                .HasMaxLength(75);

            builder
                .Property(b => b.WeightLBS)
                .HasMaxLength(75);

            builder
                .Property(b => b.LifeSpanYears)
                .HasMaxLength(75);
        }
    }

    public class ShieldConfiguration : IEntityTypeConfiguration<ShieldModel>
    {
        public void Configure(EntityTypeBuilder<ShieldModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(75);
        }
    }

    public class SpellAreaConfiguration : IEntityTypeConfiguration<SpellAreaModel>
    {
        public void Configure(EntityTypeBuilder<SpellAreaModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

        }
    }

    public class SpellCastingTimeConfiguration : IEntityTypeConfiguration<SpellCastingTimeModel>
    {
        public void Configure(EntityTypeBuilder<SpellCastingTimeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .HasMany(p => p.Spells)
                .WithOne(c => c.CastingTime)
                .HasForeignKey(c => c.CastingTimeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }

    public class SpellDurationConfiguration : IEntityTypeConfiguration<SpellDurationModel>
    {
        public void Configure(EntityTypeBuilder<SpellDurationModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .HasMany(p => p.Spells)
                .WithOne(c => c.Duration)
                .HasForeignKey(c => c.DurationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }

    public class SpellConfiguration : IEntityTypeConfiguration<SpellModel>
    {
        public void Configure(EntityTypeBuilder<SpellModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

        }
    }

    public class SpellRangeConfiguration : IEntityTypeConfiguration<SpellRangeModel>
    {
        public void Configure(EntityTypeBuilder<SpellRangeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .HasMany(p => p.Spells)
                .WithOne(c => c.Range)
                .HasForeignKey(c => c.RangeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }

    public class SpellSaveConfiguration : IEntityTypeConfiguration<SpellSaveModel>
    {
        public void Configure(EntityTypeBuilder<SpellSaveModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .HasMany(p => p.Spells)
                .WithOne(c => c.Save)
                .HasForeignKey(c => c.SaveId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }

    public class SpellSizeLimitConfiguration : IEntityTypeConfiguration<SpellSizeLimitModel>
    {
        public void Configure(EntityTypeBuilder<SpellSizeLimitModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .HasMany(p => p.Spells)
                .WithOne(c => c.SizeLimit)
                .HasForeignKey(c => c.SizeLimitId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }

    public class TalentGroupTypeConfiguration : IEntityTypeConfiguration<TalentGroupTypeModel>
    {
        public void Configure(EntityTypeBuilder<TalentGroupTypeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.GroupName)
                .HasMaxLength(75);
        }
    }

    public class TalentConfiguration : IEntityTypeConfiguration<TalentModel>
    {
        public void Configure(EntityTypeBuilder<TalentModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(150);

            builder
                .Property(b => b.Notes)
                .HasMaxLength(1500);
        }
    }

    public class TechniqueGroupTypeConfiguration : IEntityTypeConfiguration<TechniqueGroupTypeModel>
    {
        public void Configure(EntityTypeBuilder<TechniqueGroupTypeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.TechniqueGroupType)
                .HasMaxLength(75);
        }
    }

    public class TechniqueConfiguration : IEntityTypeConfiguration<TechniqueModel>
    {
        public void Configure(EntityTypeBuilder<TechniqueModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.TechniqueName)
                .HasMaxLength(150);

            builder
                .Property(b => b.Notes)
                .HasMaxLength(600);
        }
    }

    public class TownConfiguration : IEntityTypeConfiguration<TownModel>
    {
        public void Configure(EntityTypeBuilder<TownModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(75);
        }
    }

    public class WeaponConfiguration : IEntityTypeConfiguration<WeaponModel>
    {
        public void Configure(EntityTypeBuilder<WeaponModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(75);
        }
    }

    public class WeaponSizeConfiguration : IEntityTypeConfiguration<WeaponSizeModel>
    {
        public void Configure(EntityTypeBuilder<WeaponSizeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(50);
        }
    }

    public class WeaponTypeConfiguration : IEntityTypeConfiguration<WeaponTypeModel>
    {
        public void Configure(EntityTypeBuilder<WeaponTypeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(75);
        }
    }

    public class WorldConfiguration : IEntityTypeConfiguration<WorldModel>
    {
        public void Configure(EntityTypeBuilder<WorldModel> builder)
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
                .HasMany(p => p.Towns)
                .WithOne(c => c.World)
                .HasForeignKey(c => c.WorldId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }

}
