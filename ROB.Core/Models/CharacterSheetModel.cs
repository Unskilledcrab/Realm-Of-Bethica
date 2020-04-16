using System;
using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class CharacterSheetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RaceId { get; set; }
        public RaceModel Race { get; set; }
        public int Strong { get; set; } = 0;
        public int StrongModifier { get; set; }
        public int Robust { get; set; } = 0;
        public int RobustModifier { get; set; }
        public int Agile { get; set; } = 0;
        public int AgileModifier { get; set; }
        public int Precision { get; set; } = 0;
        public int PrecisionModifier { get; set; }
        public int Knowledgeable { get; set; } = 0;
        public int KnowledgeableModifier { get; set; }
        public int Headstrong { get; set; } = 0;
        public int HeadstrongModifier { get; set; }
        public int Charismatic { get; set; } = 0;
        public int CharismaticModifier { get; set; }
        public int Attractive { get; set; } = 0;
        public int AttractiveModifier { get; set; }
        public bool AreAttributesPublic { get; set; }
        public int Level { get; set; } = 1;

        #region Description
        public string Background { get; set; }
        public Alignment Alignment { get; set; }
        public string Gender { get; set; }
        public string Faith { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int HeightInches { get; set; }
        #endregion

        #region Notes
        // might make a notes class that has one private and one public
        public string PublicNotes { get; set; }
        public string PrivateNotes { get; set; }
        public string Backstory { get; set; }
        #endregion

        public bool IsPublic { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; }

        public ICollection<CharacterSheet_ParentSkill_Link> ParentSkills { get; set; } = new List<CharacterSheet_ParentSkill_Link>();
        public ICollection<CharacterSheet_ChildSkill_Link> ChildSkills { get; set; } = new List<CharacterSheet_ChildSkill_Link>();
        public ICollection<CharacterSheet_Talent_Link> Talents { get; set; } = new List<CharacterSheet_Talent_Link>();
        public ICollection<CharacterSheet_Technique_Link> Techniques { get; set; } = new List<CharacterSheet_Technique_Link>();
        public ICollection<CharacterSheet_Weapon_Link> Weapons { get; set; } = new List<CharacterSheet_Weapon_Link>();
        public ICollection<CharacterSheet_Item_Link> Items { get; set; } = new List<CharacterSheet_Item_Link>();
        public ICollection<CharacterSheet_Poison_Link> Poisons { get; set; } = new List<CharacterSheet_Poison_Link>();
        public ICollection<CharacterSheet_Spell_Link> Spells { get; set; } = new List<CharacterSheet_Spell_Link>();
        public ICollection<CharacterSheet_QuestGroup_Link> QuestGroups { get; set; } = new List<CharacterSheet_QuestGroup_Link>();
        public ICollection<CharacterSheet_Quest_Link> Quests { get; set; } = new List<CharacterSheet_Quest_Link>();
        public ICollection<Town_NPC_Link> NPCTowns { get; set; } = new List<Town_NPC_Link>();
        public ICollection<PermissionViewer_CharacterSheet_Link> PermissionViewers { get; set; } = new List<PermissionViewer_CharacterSheet_Link>();
        public ICollection<CharacterSheet_Armor_Link> Armors { get; set; } = new List<CharacterSheet_Armor_Link>();
        public ICollection<CharacterSheet_Shield_Link> Shields { get; set; } = new List<CharacterSheet_Shield_Link>();
    }

    public enum Alignment
    {
        Light,
        Neutral,
        Chaotic,
    }
}
