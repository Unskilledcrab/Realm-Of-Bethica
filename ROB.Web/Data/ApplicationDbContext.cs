using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Models;

namespace ROB.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {


            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Overrided Relationships

            #region One to Many

            #region Template
            /*
             * Just copy and paste and do a find and replace 
             * Replace ClassOne with the one relationship class
             * Replace ClassMany with the many relationship class
             * 
            #region ClassOne
            builder.Entity<ClassOneModel>()
                .HasMany(p => p.ClassManys)
                .WithOne(c => c.ClassOne)
                .HasForeignKey(c => c.ClassOneId);
            #endregion
            */
            #endregion

            #region Quest Rating
            builder.Entity<QuestRatingModel>()
                .HasMany(p => p.Quests)
                .WithOne(c => c.DifficultyRating)
                .HasForeignKey(c => c.DifficultyRatingId);
            #endregion

            #region World
            builder.Entity<WorldModel>()
                .HasMany<TownModel>(p => p.Towns)
                .WithOne(c => c.World)
                .HasForeignKey(c => c.WorldId);
            #endregion

            #region ParentSkill
            builder.Entity<ParentSkillModel>()
                .HasMany<ChildSkillModel>(p => p.ChildSkills)
                .WithOne(c => c.ParentSkill)
                .HasForeignKey(c => c.ParentSkillId);
            #endregion

            #region Application User
            builder.Entity<ApplicationUser>()
                .HasMany<PUBConGameModel>(p => p.PUBConGMGames)
                .WithOne(c => c.Creator)
                .HasForeignKey(c => c.CreatorId);

            builder.Entity<ApplicationUser>()
                .HasMany<WorldModel>(p => p.CreatedWorlds)
                .WithOne(c => c.Creator)
                .HasForeignKey(c => c.CreatorId);

            builder.Entity<ApplicationUser>()
                .HasMany<TownModel>(p => p.CreatedTowns)
                .WithOne(c => c.Creator)
                .HasForeignKey(c => c.CreatorId);

            builder.Entity<ApplicationUser>()
                .HasMany<BuildingModel>(p => p.CreatedBuildings)
                .WithOne(c => c.Creator)
                .HasForeignKey(c => c.CreatorId);

            builder.Entity<ApplicationUser>()
                .HasMany<CharacterSheetModel>(p => p.CreatedCharacterSheets)
                .WithOne(c => c.Creator)
                .HasForeignKey(c => c.CreatorId);

            builder.Entity<ApplicationUser>()
                .HasMany<QuestGroupModel>(p => p.CreatedQuestGroups)
                .WithOne(c => c.Creator)
                .HasForeignKey(c => c.CreatorId);
            #endregion

            #region Quest Group
            builder.Entity<QuestGroupModel>()
                .HasMany<QuestModel>(p => p.Quests)
                .WithOne(c => c.QuestGroup)
                .HasForeignKey(c => c.QuestGroupId);
            #endregion

            #region ArcaneSphere

            builder.Entity<ArcaneSphereModel>()
                .HasMany<ArcaneSubgroupModel>(p => p.ArcaneSubgroups)
                .WithOne(c => c.ArcaneSphere)
                .HasForeignKey(c => c.ArcaneSphereId);

            #endregion

            #region ArcaneSphere
            builder.Entity<ArcaneSphereModel>()
                .HasMany<SpellModel>(p => p.Spells)
                .WithOne(c => c.ArcaneSphere)
                .HasForeignKey(c => c.ArcaneSphereId);
            #endregion

            #region SpellArea
            builder.Entity<SpellAreaModel>()
                .HasMany<SpellModel>(p => p.Spells)
                .WithOne(c => c.Area)
                .HasForeignKey(c => c.AreaId);
            #endregion

            #region SpellCastingTime
            builder.Entity<SpellCastingTimeModel>()
                .HasMany<SpellModel>(p => p.Spells)
                .WithOne(c => c.CastingTime)
                .HasForeignKey(c => c.CastingTimeId);
            #endregion

            #region SpellDuration
            builder.Entity<SpellDurationModel>()
                .HasMany<SpellModel>(p => p.Spells)
                .WithOne(c => c.Duration)
                .HasForeignKey(c => c.DurationId);
            #endregion

            #region SpellRange
            builder.Entity<SpellRangeModel>()
                .HasMany<SpellModel>(p => p.Spells)
                .WithOne(c => c.Range)
                .HasForeignKey(c => c.RangeId);
            #endregion

            #region SpellSave
            builder.Entity<SpellSaveModel>()
                .HasMany<SpellModel>(p => p.Spells)
                .WithOne(c => c.Save)
                .HasForeignKey(c => c.SaveId);
            #endregion

            #region SpellSizeLimit
            builder.Entity<SpellSizeLimitModel>()
                .HasMany<SpellModel>(p => p.Spells)
                .WithOne(c => c.SizeLimit)
                .HasForeignKey(c => c.SizeLimitId);
            #endregion

            #endregion

            #region Many to Many

            #region Template
            /*
             * Just copy and paste and do a find and replace
             * Replace Class1 with one of the classes and Class2 with the other
             * 
             * 
            #region Class1
            builder.Entity<Class1_Class2_Link>()
                .HasKey(ttp => new { ttp.Class1Id, ttp.Class2Id });

            builder.Entity<Class1_Class2_Link>()
                .HasOne(tm => tm.Class1)
                .WithMany(tpp => tpp.Class2s)
                .HasForeignKey(tm => tm.Class1Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Class1_Class2_Link>()
                .HasOne(tm => tm.Class2)
                .WithMany(tmm => tmm.Class1s)
                .HasForeignKey(tm => tm.Class2Id)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
            */
            #endregion


            #region PUBConGame
            builder.Entity<User_PUBConGame_Link>()
                .HasKey(ttp => new { ttp.PUBConGameId, ttp.UserId });

            builder.Entity<User_PUBConGame_Link>()
                .HasOne(tm => tm.PUBConGame)
                .WithMany(tpp => tpp.Players)
                .HasForeignKey(tm => tm.PUBConGameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User_PUBConGame_Link>()
                .HasOne(tm => tm.User)
                .WithMany(tmm => tmm.PUBConGames)
                .HasForeignKey(tm => tm.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Quest
            builder.Entity<Quest_QuestTag_Link>()
               .HasKey(ttp => new { ttp.QuestId, ttp.QuestTagId });

            builder.Entity<Quest_QuestTag_Link>()
                .HasOne<QuestModel>(tm => tm.Quest)
                .WithMany(tpp => tpp.QuestTags)
                .HasForeignKey(tm => tm.QuestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Quest_QuestTag_Link>()
                .HasOne<QuestTagModel>(tm => tm.QuestTag)
                .WithMany(tmm => tmm.Quests)
                .HasForeignKey(tm => tm.QuestTagId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Building
            builder.Entity<Building_Item_Link>()
                .HasKey(ttp => new { ttp.BuildingId, ttp.ItemId });

            builder.Entity<Building_Item_Link>()
                .HasOne<BuildingModel>(tm => tm.Building)
                .WithMany(tpp => tpp.Items)
                .HasForeignKey(tm => tm.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Building_Item_Link>()
                .HasOne<ItemModel>(tm => tm.Item)
                .WithMany(tmm => tmm.Buildings)
                .HasForeignKey(tm => tm.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Building_Poison_Link>()
                .HasKey(ttp => new { ttp.BuildingId, ttp.PoisonId });

            builder.Entity<Building_Poison_Link>()
                .HasOne<BuildingModel>(tm => tm.Building)
                .WithMany(tpp => tpp.Poisons)
                .HasForeignKey(tm => tm.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Building_Poison_Link>()
                .HasOne<PoisonModel>(tm => tm.Poison)
                .WithMany(tmm => tmm.Buildings)
                .HasForeignKey(tm => tm.PoisonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Building_Shield_Link>()
                .HasKey(ttp => new { ttp.BuildingId, ttp.ShieldId });

            builder.Entity<Building_Shield_Link>()
                .HasOne<BuildingModel>(tm => tm.Building)
                .WithMany(tpp => tpp.Shields)
                .HasForeignKey(tm => tm.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Building_Shield_Link>()
                .HasOne<ShieldModel>(tm => tm.Shield)
                .WithMany(tmm => tmm.Buildings)
                .HasForeignKey(tm => tm.ShieldId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Building_Armor_Link>()
                .HasKey(ttp => new { ttp.BuildingId, ttp.ArmorId });

            builder.Entity<Building_Armor_Link>()
                .HasOne<BuildingModel>(tm => tm.Building)
                .WithMany(tpp => tpp.Armors)
                .HasForeignKey(tm => tm.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Building_Armor_Link>()
                .HasOne<ArmorModel>(tm => tm.Armor)
                .WithMany(tmm => tmm.Buildings)
                .HasForeignKey(tm => tm.ArmorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Building_Weapon_Link>()
                .HasKey(ttp => new { ttp.BuildingId, ttp.WeaponId });

            builder.Entity<Building_Weapon_Link>()
                .HasOne<BuildingModel>(tm => tm.Building)
                .WithMany(tpp => tpp.Weapons)
                .HasForeignKey(tm => tm.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Building_Weapon_Link>()
                .HasOne<WeaponModel>(tm => tm.Weapon)
                .WithMany(tmm => tmm.Buildings)
                .HasForeignKey(tm => tm.WeaponId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Town
            builder.Entity<Town_Building_Link>()
                .HasKey(ttp => new { ttp.TownId, ttp.BuildingId });

            builder.Entity<Town_Building_Link>()
                .HasOne<TownModel>(tm => tm.Town)
                .WithMany(tpp => tpp.Buildings)
                .HasForeignKey(tm => tm.TownId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Town_Building_Link>()
                .HasOne<BuildingModel>(tm => tm.Building)
                .WithMany(tmm => tmm.Towns)
                .HasForeignKey(tm => tm.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Town_NPC_Link>()
                .HasKey(ttp => new { ttp.CharacterSheetId, ttp.TownId });

            builder.Entity<Town_NPC_Link>()
                .HasOne<CharacterSheetModel>(tm => tm.CharacterSheet)
                .WithMany(tpp => tpp.NPCTowns)
                .HasForeignKey(tm => tm.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Town_NPC_Link>()
                .HasOne<TownModel>(tm => tm.Town)
                .WithMany(tmm => tmm.NPCs)
                .HasForeignKey(tm => tm.TownId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Application User

            #region Viewing Permissions
            builder.Entity<PermissionViewer_QuestGroup_Link>()
                .HasKey(ttp => new { ttp.QuestGroupId, ttp.ApplicationUserId });

            builder.Entity<PermissionViewer_QuestGroup_Link>()
                .HasOne<QuestGroupModel>(tm => tm.QuestGroup)
                .WithMany(tpp => tpp.PermissionViewers)
                .HasForeignKey(tm => tm.QuestGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PermissionViewer_QuestGroup_Link>()
                .HasOne<ApplicationUser>(tm => tm.ApplicationUser)
                .WithMany(tmm => tmm.ViewableQuestGroups)
                .HasForeignKey(tm => tm.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PermissionViewer_Town_Link>()
                .HasKey(ttp => new { ttp.TownId, ttp.ApplicationUserId });

            builder.Entity<PermissionViewer_Town_Link>()
                .HasOne<TownModel>(tm => tm.Town)
                .WithMany(tpp => tpp.PermissionViewers)
                .HasForeignKey(tm => tm.TownId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PermissionViewer_Town_Link>()
                .HasOne<ApplicationUser>(tm => tm.ApplicationUser)
                .WithMany(tmm => tmm.ViewableTowns)
                .HasForeignKey(tm => tm.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PermissionViewer_CharacterSheet_Link>()
                .HasKey(ttp => new { ttp.CharacterSheetId, ttp.ApplicationUserId });

            builder.Entity<PermissionViewer_CharacterSheet_Link>()
                .HasOne<CharacterSheetModel>(tm => tm.CharacterSheet)
                .WithMany(tpp => tpp.PermissionViewers)
                .HasForeignKey(tm => tm.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PermissionViewer_CharacterSheet_Link>()
                .HasOne<ApplicationUser>(tm => tm.ApplicationUser)
                .WithMany(tmm => tmm.ViewableCharacterSheets)
                .HasForeignKey(tm => tm.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PermissionViewer_Building_Link>()
                .HasKey(ttp => new { ttp.BuildingId, ttp.ApplicationUserId });

            builder.Entity<PermissionViewer_Building_Link>()
                .HasOne<BuildingModel>(tm => tm.Building)
                .WithMany(tpp => tpp.PermissionViewers)
                .HasForeignKey(tm => tm.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PermissionViewer_Building_Link>()
                .HasOne<ApplicationUser>(tm => tm.ApplicationUser)
                .WithMany(tmm => tmm.ViewableBuildings)
                .HasForeignKey(tm => tm.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PermissionViewer_World_Link>()
                .HasKey(ttp => new { ttp.WorldId, ttp.ApplicationUserId });

            builder.Entity<PermissionViewer_World_Link>()
                .HasOne<WorldModel>(tm => tm.World)
                .WithMany(tpp => tpp.PermissionViewers)
                .HasForeignKey(tm => tm.WorldId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PermissionViewer_World_Link>()
                .HasOne<ApplicationUser>(tm => tm.ApplicationUser)
                .WithMany(tmm => tmm.ViewableWorlds)
                .HasForeignKey(tm => tm.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PermissionViewer_Quest_Link>()
                .HasKey(ttp => new { ttp.QuestId, ttp.ApplicationUserId });

            builder.Entity<PermissionViewer_Quest_Link>()
                .HasOne<QuestModel>(tm => tm.Quest)
                .WithMany(tpp => tpp.PermissionViewers)
                .HasForeignKey(tm => tm.QuestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PermissionViewer_Quest_Link>()
                .HasOne<ApplicationUser>(tm => tm.ApplicationUser)
                .WithMany(tmm => tmm.ViewableQuests)
                .HasForeignKey(tm => tm.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #endregion

            #region Techniques
            builder.Entity<TechniqueTalentPrerequisiteLink>()
                .Property(t => t.TalentId).IsRequired(false);

            builder.Entity<TechniqueTalentPrerequisiteLink>()
                .Property(t => t.TechniqueId).IsRequired(false);

            builder.Entity<TechniqueTalentPrerequisiteLink>()
                .HasKey(ttp => new { ttp.TalentId, ttp.TechniqueId });

            builder.Entity<TechniqueTalentPrerequisiteLink>()
                .HasOne<TechniqueModel>(tm => tm.Technique)
                .WithMany(tpp => tpp.TalentPrerequisites)
                .HasForeignKey(tm => tm.TechniqueId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<TechniqueTalentPrerequisiteLink>()
                .HasOne<TalentModel>(tm => tm.TalentPrerequisite)
                .WithMany(tmm => tmm.TechniqueConnection)
                .HasForeignKey(tm => tm.TalentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<TechniquePrerequisiteLink>()
                .HasKey(tp => new { tp.TechniqueModelId, tp.PrerequisiteId });

            builder.Entity<TechniquePrerequisiteLink>()
                .HasOne<TechniqueModel>(tm => tm.Technique)
                .WithMany(tp => tp.TechniquePrerequisites)
                .HasForeignKey(tm => tm.TechniqueModelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TechniquePrerequisiteLink>()
                .HasOne<TechniqueModel>(tm => tm.Prerequisite)
                .WithMany(tp => tp.TechniqueBases)
                .HasForeignKey(tm => tm.PrerequisiteId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Talents
            builder.Entity<TalentPrerequisiteLink>()
                .HasKey(tp => new { tp.TalentId, tp.PrerequisiteId });

            builder.Entity<TalentPrerequisiteLink>()
                .HasOne<TalentModel>(tm => tm.Talent)
                .WithMany(tp => tp.TalentPrerequisites)
                .HasForeignKey(tm => tm.TalentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TalentPrerequisiteLink>()
                .HasOne<TalentModel>(tm => tm.Prerequisite)
                .WithMany(tp => tp.TalentBases)
                .HasForeignKey(tm => tm.PrerequisiteId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Pregens
            builder.Entity<PregenProfessionArchetype_ChildSkill_LinkModel>()
                .HasKey(ttp => new { ttp.ChildSkillId, ttp.PregenProfessionArchetypeId });

            builder.Entity<PregenProfessionArchetype_ChildSkill_LinkModel>()
                .HasOne<PregenProfessionArchetypeModel>(tm => tm.PregenProfessionArchetype)
                .WithMany(tpp => tpp.ChildSkills)
                .HasForeignKey(tm => tm.PregenProfessionArchetypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PregenProfessionArchetype_ChildSkill_LinkModel>()
                .HasOne<ChildSkillModel>(tm => tm.ChildSkill)
                .WithMany(tmm => tmm.PregenProfessionArchetypeLink)
                .HasForeignKey(tm => tm.ChildSkillId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PregenProfessionArchetype_ParentSkill_LinkModel>()
                .HasKey(ttp => new { ttp.ParentSkillId, ttp.PregenProfessionArchetypeId });

            builder.Entity<PregenProfessionArchetype_ParentSkill_LinkModel>()
                .HasOne<PregenProfessionArchetypeModel>(tm => tm.PregenProfessionArchetype)
                .WithMany(tpp => tpp.TrainedParentSkills)
                .HasForeignKey(tm => tm.PregenProfessionArchetypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PregenProfessionArchetype_ParentSkill_LinkModel>()
                .HasOne<ParentSkillModel>(tm => tm.ParentSkill)
                .WithMany(tmm => tmm.PregenProfessionArchetypeLink)
                .HasForeignKey(tm => tm.ParentSkillId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PregenProfessionArchetype_Talent_LinkModel>()
                .HasKey(ttp => new { ttp.TalentId, ttp.PregenProfessionArchetypeId });

            builder.Entity<PregenProfessionArchetype_Talent_LinkModel>()
                .HasOne<PregenProfessionArchetypeModel>(tm => tm.PregenProfessionArchetype)
                .WithMany(tpp => tpp.Talents)
                .HasForeignKey(tm => tm.PregenProfessionArchetypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PregenProfessionArchetype_Talent_LinkModel>()
                .HasOne<TalentModel>(tm => tm.Talent)
                .WithMany(tmm => tmm.PregenProfessionArchetypeLink)
                .HasForeignKey(tm => tm.TalentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PregenProfessionArchetype_Technique_LinkModel>()
                .HasKey(ttp => new { ttp.TechniqueId, ttp.PregenProfessionArchetypeId });

            builder.Entity<PregenProfessionArchetype_Technique_LinkModel>()
                .HasOne<PregenProfessionArchetypeModel>(tm => tm.PregenProfessionArchetype)
                .WithMany(tpp => tpp.Techniques)
                .HasForeignKey(tm => tm.PregenProfessionArchetypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PregenProfessionArchetype_Technique_LinkModel>()
                .HasOne<TechniqueModel>(tm => tm.Technique)
                .WithMany(tmm => tmm.PregenProfessionArchetypeLink)
                .HasForeignKey(tm => tm.TechniqueId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Character Sheets
            builder.Entity<CharacterSheet_Shield_Link>()
                .HasKey(ttp => new { ttp.CharacterSheetId, ttp.ShieldId });

            builder.Entity<CharacterSheet_Shield_Link>()
                .HasOne<CharacterSheetModel>(tm => tm.CharacterSheet)
                .WithMany(tpp => tpp.Shields)
                .HasForeignKey(tm => tm.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_Shield_Link>()
                .HasOne<ShieldModel>(tm => tm.Shield)
                .WithMany(tmm => tmm.CharacterSheets)
                .HasForeignKey(tm => tm.ShieldId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_Armor_Link>()
                .HasKey(ttp => new { ttp.CharacterSheetId, ttp.ArmorId });

            builder.Entity<CharacterSheet_Armor_Link>()
                .HasOne<CharacterSheetModel>(tm => tm.CharacterSheet)
                .WithMany(tpp => tpp.Armors)
                .HasForeignKey(tm => tm.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_Armor_Link>()
                .HasOne<ArmorModel>(tm => tm.Armor)
                .WithMany(tmm => tmm.CharacterSheets)
                .HasForeignKey(tm => tm.ArmorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_ChildSkill_Link>()
                .HasKey(ttp => new { ttp.CharacterSheetId, ttp.ChildSkillId });

            builder.Entity<CharacterSheet_ChildSkill_Link>()
                .HasOne<CharacterSheetModel>(tm => tm.CharacterSheet)
                .WithMany(tpp => tpp.ChildSkills)
                .HasForeignKey(tm => tm.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_ChildSkill_Link>()
                .HasOne<ChildSkillModel>(tm => tm.ChildSkill)
                .WithMany(tmm => tmm.CharacterSheets)
                .HasForeignKey(tm => tm.ChildSkillId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_ParentSkill_Link>()
                .HasKey(ttp => new { ttp.CharacterSheetId, ttp.ParentSkillId });

            builder.Entity<CharacterSheet_ParentSkill_Link>()
                .HasOne<CharacterSheetModel>(tm => tm.CharacterSheet)
                .WithMany(tpp => tpp.ParentSkills)
                .HasForeignKey(tm => tm.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_ParentSkill_Link>()
                .HasOne<ParentSkillModel>(tm => tm.ParentSkill)
                .WithMany(tmm => tmm.CharacterSheets)
                .HasForeignKey(tm => tm.ParentSkillId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_Talent_Link>()
                .HasKey(ttp => new { ttp.CharacterSheetId, ttp.TalentId });

            builder.Entity<CharacterSheet_Talent_Link>()
                .HasOne<CharacterSheetModel>(tm => tm.CharacterSheet)
                .WithMany(tpp => tpp.Talents)
                .HasForeignKey(tm => tm.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_Talent_Link>()
                .HasOne<TalentModel>(tm => tm.Talent)
                .WithMany(tmm => tmm.CharacterSheets)
                .HasForeignKey(tm => tm.TalentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_Technique_Link>()
                .HasKey(ttp => new { ttp.CharacterSheetId, ttp.TechniqueId });

            builder.Entity<CharacterSheet_Technique_Link>()
                .HasOne<CharacterSheetModel>(tm => tm.CharacterSheet)
                .WithMany(tpp => tpp.Techniques)
                .HasForeignKey(tm => tm.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_Technique_Link>()
                .HasOne<TechniqueModel>(tm => tm.Technique)
                .WithMany(tmm => tmm.CharacterSheets)
                .HasForeignKey(tm => tm.TechniqueId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_Weapon_Link>()
                .HasKey(ttp => new { ttp.CharacterSheetId, ttp.WeaponId });

            builder.Entity<CharacterSheet_Weapon_Link>()
                .HasOne<CharacterSheetModel>(tm => tm.CharacterSheet)
                .WithMany(tpp => tpp.Weapons)
                .HasForeignKey(tm => tm.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_Weapon_Link>()
                .HasOne<WeaponModel>(tm => tm.Weapon)
                .WithMany(tmm => tmm.CharacterSheets)
                .HasForeignKey(tm => tm.WeaponId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_Poison_Link>()
                .HasKey(ttp => new { ttp.CharacterSheetId, ttp.PoisonId });

            builder.Entity<CharacterSheet_Poison_Link>()
                .HasOne<CharacterSheetModel>(tm => tm.CharacterSheet)
                .WithMany(tpp => tpp.Poisons)
                .HasForeignKey(tm => tm.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_Poison_Link>()
                .HasOne<PoisonModel>(tm => tm.Poison)
                .WithMany(tmm => tmm.CharacterSheets)
                .HasForeignKey(tm => tm.PoisonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_Item_Link>()
                .HasKey(ttp => new { ttp.CharacterSheetId, ttp.ItemId });

            builder.Entity<CharacterSheet_Item_Link>()
                .HasOne<CharacterSheetModel>(tm => tm.CharacterSheet)
                .WithMany(tpp => tpp.Items)
                .HasForeignKey(tm => tm.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_Item_Link>()
                .HasOne<ItemModel>(tm => tm.Item)
                .WithMany(tmm => tmm.CharacterSheets)
                .HasForeignKey(tm => tm.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_Spell_Link>()
                .HasKey(ttp => new { ttp.CharacterSheetId, ttp.SpellId });

            builder.Entity<CharacterSheet_Spell_Link>()
                .HasOne<CharacterSheetModel>(tm => tm.CharacterSheet)
                .WithMany(tpp => tpp.Spells)
                .HasForeignKey(tm => tm.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_Spell_Link>()
                .HasOne<SpellModel>(tm => tm.Spell)
                .WithMany(tmm => tmm.CharacterSheets)
                .HasForeignKey(tm => tm.SpellId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_QuestGroup_Link>()
                .HasKey(ttp => new { ttp.CharacterSheetId, ttp.QuestGroupId });

            builder.Entity<CharacterSheet_QuestGroup_Link>()
                .HasOne<CharacterSheetModel>(tm => tm.CharacterSheet)
                .WithMany(tpp => tpp.QuestGroups)
                .HasForeignKey(tm => tm.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_QuestGroup_Link>()
                .HasOne<QuestGroupModel>(tm => tm.QuestGroup)
                .WithMany(tmm => tmm.CharacterSheets)
                .HasForeignKey(tm => tm.QuestGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_Quest_Link>()
                .HasKey(ttp => new { ttp.CharacterSheetId, ttp.QuestId });

            builder.Entity<CharacterSheet_Quest_Link>()
                .HasOne<CharacterSheetModel>(tm => tm.CharacterSheet)
                .WithMany(tpp => tpp.Quests)
                .HasForeignKey(tm => tm.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CharacterSheet_Quest_Link>()
                .HasOne<QuestModel>(tm => tm.Quest)
                .WithMany(tmm => tmm.CharacterSheets)
                .HasForeignKey(tm => tm.QuestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PermissionViewer_CharacterSheet_Link>()
                .HasKey(ttp => new { ttp.CharacterSheetId, ttp.ApplicationUserId });

            builder.Entity<PermissionViewer_CharacterSheet_Link>()
                .HasOne<CharacterSheetModel>(tm => tm.CharacterSheet)
                .WithMany(tpp => tpp.PermissionViewers)
                .HasForeignKey(tm => tm.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PermissionViewer_CharacterSheet_Link>()
                .HasOne<ApplicationUser>(tm => tm.ApplicationUser)
                .WithMany(tmm => tmm.ViewableCharacterSheets)
                .HasForeignKey(tm => tm.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Modifiers
            builder.Entity<Modifier_Race_Link>()
                .HasKey(ttp => new { ttp.ModifierId, ttp.RaceId });

            builder.Entity<Modifier_Race_Link>()
                .HasOne<ModifierModel>(tm => tm.Modifier)
                .WithMany(tpp => tpp.Races)
                .HasForeignKey(tm => tm.ModifierId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Modifier_Race_Link>()
                .HasOne<RaceModel>(tm => tm.Race)
                .WithMany(tmm => tmm.Modifiers)
                .HasForeignKey(tm => tm.RaceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Modifier_Technique_Link>()
                .HasKey(ttp => new { ttp.ModifierId, ttp.TechniqueId });

            builder.Entity<Modifier_Technique_Link>()
                .HasOne<ModifierModel>(tm => tm.Modifier)
                .WithMany(tpp => tpp.Techniques)
                .HasForeignKey(tm => tm.ModifierId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Modifier_Technique_Link>()
                .HasOne<TechniqueModel>(tm => tm.Technique)
                .WithMany(tmm => tmm.Modifiers)
                .HasForeignKey(tm => tm.TechniqueId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region ArcaneSphere

            builder.Entity<ArcaneSubgroup_ArcanePowerAttribute_Link>()
                .HasKey(ttp => new { ttp.ArcaneSubgroupId, ttp.ArcanePowerAttributeId });

            builder.Entity<ArcaneSubgroup_ArcanePowerAttribute_Link>()
                .HasOne<ArcaneSubgroupModel>(tm => tm.ArcaneSubgroup)
                .WithMany(tpp => tpp.ElementsUsedIn)
                .HasForeignKey(tm => tm.ArcaneSubgroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ArcaneSubgroup_ArcanePowerAttribute_Link>()
                .HasOne<ArcanePowerAttributeModel>(tm => tm.ArcanePowerAttribute)
                .WithMany(tmm => tmm.RequiredArcaneSubgroups)
                .HasForeignKey(tm => tm.ArcanePowerAttributeId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Spell
            builder.Entity<Spell_ArcanePowerAttribute_Link>()
                .HasKey(ttp => new { ttp.SpellId, ttp.ArcanePowerAttributeId });

            builder.Entity<Spell_ArcanePowerAttribute_Link>()
                .HasOne<SpellModel>(tm => tm.Spell)
                .WithMany(tpp => tpp.ArcanePowerAttributes)
                .HasForeignKey(tm => tm.SpellId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Spell_ArcanePowerAttribute_Link>()
                .HasOne<ArcanePowerAttributeModel>(tm => tm.ArcanePowerAttribute)
                .WithMany(tmm => tmm.Spells)
                .HasForeignKey(tm => tm.ArcanePowerAttributeId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Item Packs
            builder.Entity<ItemPack_Item_Link>()
                .HasKey(ttp => new { ttp.ItemPackId, ttp.ItemId });

            builder.Entity<ItemPack_Item_Link>()
                .HasOne<ItemPackModel>(tm => tm.ItemPack)
                .WithMany(tpp => tpp.Items)
                .HasForeignKey(tm => tm.ItemPackId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ItemPack_Item_Link>()
                .HasOne<ItemModel>(tm => tm.Item)
                .WithMany(tmm => tmm.ItemPacks)
                .HasForeignKey(tm => tm.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #endregion

            #endregion
        }
        public DbSet<ROB.Web.Models.ChildSkillModel> ChildSkillModel { get; set; }
        public DbSet<ROB.Web.Models.LanguageModel> LanguageModel { get; set; }
        public DbSet<ROB.Web.Models.TechniqueGroupTypeModel> TechniqueGroupTypeModel { get; set; }
        public DbSet<ROB.Web.Models.LanguageGroupTypeModel> LanguageGroupTypeModel { get; set; }
        public DbSet<ROB.Web.Models.TechniqueModel> TechniqueModel { get; set; }
        public DbSet<ROB.Web.Models.TechniquePrerequisiteLink> TechniquePrerequisitesLink { get; set; }
        public DbSet<ROB.Web.Models.TechniqueTalentPrerequisiteLink> TechniqueTalentPrerequisiteLinks { get; set; }
        public DbSet<ROB.Web.Models.ParentSkillModel> ParentSkillModel { get; set; }
        public DbSet<ROB.Web.Models.AttributeModel> AttributeModel { get; set; }
        public DbSet<ROB.Web.Models.TalentModel> TalentModel { get; set; }
        public DbSet<ROB.Web.Models.TalentPrerequisiteLink> TalentPrerequisiteLink { get; set; }
        public DbSet<ROB.Web.Models.TalentGroupTypeModel> TalentGroupTypeModel { get; set; }
        public DbSet<ROB.Web.Models.ModifierModel> ModifierModel { get; set; }
        public DbSet<ROB.Web.Models.RaceModel> RaceModel { get; set; }
        public DbSet<ROB.Web.Models.PregenProfessionArchetypeModel> PregenProfessionArchetypeModel { get; set; }
        public DbSet<ROB.Web.Models.CharacterSheetModel> CharacterSheetModel { get; set; }
        public DbSet<ROB.Web.Models.WeaponSizeModel> WeaponSizeModel { get; set; }
        public DbSet<ROB.Web.Models.WeaponTypeModel> WeaponTypeModel { get; set; }
        public DbSet<ROB.Web.Models.DamageTypeModel> DamageTypeModel { get; set; }
        public DbSet<ROB.Web.Models.WeaponModel> WeaponModel { get; set; }
        public DbSet<ROB.Web.Models.ItemModel> ItemModel { get; set; }
        public DbSet<ROB.Web.Models.PoisonModel> PoisonModel { get; set; }
        public DbSet<ROB.Web.Models.ItemCategoryModel> ItemCategoryModel { get; set; }
        public DbSet<ROB.Web.Models.PoisonClassModel> PoisonClassModel { get; set; }
        public DbSet<ROB.Web.Models.PoisonTypeModel> PoisonTypeModel { get; set; }
        public DbSet<ROB.Web.Models.ArcaneSphereModel> ArcaneSphereModel { get; set; }
        public DbSet<ROB.Web.Models.SpellRangeModel> SpellRangeModel { get; set; }
        public DbSet<ROB.Web.Models.SpellAreaModel> SpellAreaModel { get; set; }
        public DbSet<ROB.Web.Models.SpellDurationModel> SpellDurationModel { get; set; }
        public DbSet<ROB.Web.Models.SpellSaveModel> SpellSaveModel { get; set; }
        public DbSet<ROB.Web.Models.SpellSizeLimitModel> SpellSizeLimitModel { get; set; }
        public DbSet<ROB.Web.Models.SpellCastingTimeModel> SpellCastingTimeModel { get; set; }
        public DbSet<ROB.Web.Models.SpellModel> SpellModel { get; set; }
        public DbSet<ROB.Web.Models.ShieldModel> ShieldModel { get; set; }
        public DbSet<ROB.Web.Models.ArmorRestorationModel> ArmorRestorationModel { get; set; }
        public DbSet<ROB.Web.Models.ArmorRestrictionModel> ArmorRestrictionModel { get; set; }
        public DbSet<ROB.Web.Models.ArmorModel> ArmorModel { get; set; }
        public DbSet<ROB.Web.Models.WorldModel> WorldModel { get; set; }
        public DbSet<ROB.Web.Models.ItemPackModel> ItemPackModel { get; set; }
        public DbSet<ROB.Web.Models.PUBConGameModel> PUBConGameModel { get; set; }
        public DbSet<ROB.Core.Models.TrelloSuggestionModel> TrelloSuggestionModel { get; set; }
    }
}
