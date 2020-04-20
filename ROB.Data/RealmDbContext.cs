using Microsoft.EntityFrameworkCore;
using ROB.Core.Models;
using ROB.Data.Configurations;
using System;
using System.Reflection;

namespace ROB.Data
{
    public class RealmDbContext : DbContext
    {   
        public RealmDbContext(DbContextOptions<RealmDbContext> options) : base(options) { }

        /// <summary>
        /// Gathers all configurations in the assembly and configures them
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {           
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<ArcanePowerAttributeModel> ArcanePowerAttribute { get; set; }

        public DbSet<ArcaneSphereModel> ArcaneSphere { get; set; }

        public DbSet<ArcaneSubgroupModel> ArcaneSubgroup { get; set; }

        public DbSet<ArmorModel> Armor { get; set; }

        public DbSet<ArmorRestorationModel> ArmorRestoration { get; set; }

        public DbSet<ArmorRestrictionModel> ArmorRestriction { get; set; }

        public DbSet<AttributeModel> Attribute { get; set; }

        public DbSet<BuildingModel> Building { get; set; }

        public DbSet<BuildingRatingModel> BuildingRating { get; set; }

        public DbSet<BuildingSpecialtyModel> BuildingSpecialty { get; set; }

        public DbSet<BuildingTypeModel> BuildingType { get; set; }

        public DbSet<CharacterAttributeModel> CharacterAttribute { get; set; }

        public DbSet<CharacterSheetModel> CharacterSheet { get; set; }

        public DbSet<ChildSkillModel> ChildSkill { get; set; }

        public DbSet<DamageTypeModel> DamageType { get; set; }

        public DbSet<ItemCategoryModel> ItemCategory { get; set; }

        public DbSet<ItemModel> Item { get; set; }

        public DbSet<ItemPackModel> ItemPack { get; set; }

        public DbSet<LanguageGroupTypeModel> LanguageGroupType { get; set; }

        public DbSet<LanguageModel> Language { get; set; }

        public DbSet<ModifierModel> Modifier { get; set; }

        public DbSet<ParentSkillModel> ParentSkill { get; set; }

        public DbSet<PoisonClassModel> PoisonClass { get; set; }

        public DbSet<PoisonModel> Poison { get; set; }

        public DbSet<PoisonTypeModel> PoisonType { get; set; }

        public DbSet<PregenProfessionArchetypeModel> PregenProfessionArchetype { get; set; }

        public DbSet<QuestGroupModel> QuestGroup { get; set; }

        public DbSet<QuestModel> Quest { get; set; }

        public DbSet<QuestRatingModel> QuestRating { get; set; }

        public DbSet<QuestTagModel> QuestTag { get; set; }

        public DbSet<RaceModel> Race { get; set; }

        public DbSet<ShieldModel> Shield { get; set; }

        public DbSet<SpellAreaModel> SpellArea { get; set; }

        public DbSet<SpellCastingTimeModel> SpellCastingTime { get; set; }

        public DbSet<SpellDurationModel> SpellDuration { get; set; }

        public DbSet<SpellModel> Spell { get; set; }

        public DbSet<SpellRangeModel> SpellRange { get; set; }

        public DbSet<SpellSaveModel> SpellSave { get; set; }

        public DbSet<SpellSizeLimitModel> SpellSizeLimit { get; set; }

        public DbSet<TalentGroupTypeModel> TalentGroupType { get; set; }

        public DbSet<TalentModel> Talent { get; set; }

        public DbSet<TechniqueGroupTypeModel> TechniqueGroupType { get; set; }

        public DbSet<TechniqueModel> Technique { get; set; }

        public DbSet<TownModel> Town { get; set; }

        public DbSet<WeaponModel> Weapon { get; set; }

        public DbSet<WeaponSizeModel> WeaponSize { get; set; }

        public DbSet<WeaponTypeModel> WeaponType { get; set; }

        public DbSet<WorldModel> World { get; set; }
    }
}
