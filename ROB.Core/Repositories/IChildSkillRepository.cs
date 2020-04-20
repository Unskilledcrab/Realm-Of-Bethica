using ROB.Core.Models;

namespace ROB.Core.Repositories
{
    public interface IChildSkillRepository : ILinkRepository<ChildSkillModel> { }
    public interface IApplicationUserRepository : ILinkRepository<ApplicationUser> { }

    public interface IArcanePowerAttributeRepository : ILinkRepository<ArcanePowerAttributeModel> { }

    public interface IArcaneSphereRepository : ILinkRepository<ArcaneSphereModel> { }

    public interface IArcaneSubgroupRepository : ILinkRepository<ArcaneSubgroupModel> { }

    public interface IArmorRestorationRepository : IRepository<ArmorRestorationModel> { }


    public interface IArmorRestrictionRepository : IRepository<ArmorRestrictionModel> { }

    public interface IAttributeRepository : IRepository<AttributeModel> { }


    public interface IBuildingRepository : ILinkRepository<BuildingModel> { }

    public interface IBuildingRatingRepository : IRepository<BuildingRatingModel> { }

    public interface IBuildingSpecialtyRepository : IRepository<BuildingSpecialtyModel> { }

    public interface IBuildingTypeRepository : IRepository<BuildingTypeModel> { }

    public interface ICharacterAttributeRepository : IRepository<CharacterAttributeModel> { }

    public interface ICharacterSheetRepository : ILinkRepository<CharacterSheetModel> { }

    public interface IDamageTypeRepository : IRepository<DamageTypeModel> { }

    public interface IItemCategoryRepository : IRepository<ItemCategoryModel> { }

    public interface IItemPackRepository : ILinkRepository<ItemPackModel> { }

    public interface ILanguageGroupTypeRepository : IRepository<LanguageGroupTypeModel> { }

    public interface ILanguageRepository : IRepository<LanguageModel> { }

    public interface IModifierRepository : ILinkRepository<ModifierModel> { }

    public interface IParentSkillRepository : ILinkRepository<ParentSkillModel> { }

    public interface IPoisonClassRepository : IRepository<PoisonClassModel> { }

    public interface IPoisonRepository : ILinkRepository<PoisonModel> { }

    public interface IPoisonTypeRepository : IRepository<PoisonTypeModel> { }

    public interface IPregenProfessionArchetypeRepository : ILinkRepository<PregenProfessionArchetypeModel> { }



}
