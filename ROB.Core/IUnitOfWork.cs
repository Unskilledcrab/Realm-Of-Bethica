using System;
using System.Threading.Tasks;
using ROB.Core.Repositories;

namespace ROB.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationUserRepository User { get; }

        IArcanePowerAttributeRepository ArcanePowerAttribute { get; }

        IArcaneSphereRepository ArcaneSphere { get; }

        IArcaneSubgroupRepository ArcaneSubgroup { get; }

        IArmorRepository Armor { get; }

        IArmorRestorationRepository ArmorRestoration { get; }

        IArmorRestrictionRepository ArmorRestriction { get; }

        IAttributeRepository Attribute { get; }

        IBuildingRatingRepository BuildingRating { get; }

        IBuildingRepository Building { get; }

        IBuildingSpecialtyRepository BuildingSpecialty { get; }

        IBuildingTypeRepository BuildingType { get; }

        ICharacterAttributeRepository CharacterAttribute { get; }

        ICharacterSheetRepository CharacterSheet { get; }

        IChildSkillRepository ChildSkill { get; }

        IDamageTypeRepository DamageType { get; }

        IItemCategoryRepository ItemCategory { get; }

        IItemPackRepository ItemPack { get; }

        IItemRepository Item { get; }

        ILanguageGroupTypeRepository LanguageGroupType { get; }

        ILanguageRepository Language { get; }

        IModifierRepository Modifier { get; }

        IParentSkillRepository ParentSkill { get; }

        IPoisonClassRepository PoisonClass { get; }

        IPoisonRepository Poison { get; }

        IPoisonTypeRepository PoisonType { get; }

        IPregenProfessionArchetypeRepository PregenProfessionArchetype { get; }

        IQuestGroupRepository QuestGroup { get; }

        IQuestRatingRepository QuestRating { get; }

        IQuestRepository Quest { get; }

        IQuestTagRepository QuestTag { get; }

        IRaceRepository Race { get; }

        IShieldRepository Shield { get; }

        ISpellAreaRepository SpellArea { get; }

        ISpellCastingTimeRepository SpellCastingTime { get; }

        ISpellDurationRepository SpellDuration { get; }

        ISpellRangeRepository SpellRange { get; }

        ISpellRepository Spell { get; }

        ISpellSaveRepository SpellSave { get; }

        ISpellSizeLimitRepository SpellSizeLimit { get; }

        ITalentGroupTypeRepository TalentGroupType { get; }

        ITalentRepository Talent { get; }

        ITechniqueGroupTypeRepository TechniqueGroupType { get; }

        ITechniqueRepository Technique { get; }

        ITownRepository Town { get; }

        IWeaponRepository Weapon { get; }

        IWeaponSizeRepository WeaponSize { get; }

        IWeaponTypeRepository WeaponType { get; }

        IWorldRepository World { get; }

        Task<int> CommitAsync();
    }
}
