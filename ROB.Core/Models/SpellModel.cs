using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class SpellModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpellLevel {
            get
            {
                int spellLevel = 0;
                spellLevel = ArcaneTargetNumber / 10;
                if (spellLevel % 2 == 0)
                    return spellLevel;
                else
                {
                    spellLevel += 1;
                    return spellLevel;
                }
            }
        }
        public int ArcaneSphereId { get; set; }
        public ArcaneSphereModel ArcaneSphere { get; set; }
        public int RangeId { get; set; }
        public SpellRangeModel Range { get; set; }
        public int AreaId { get; set; }
        public SpellAreaModel Area { get; set; }
        public int SizeLimitId { get; set; }
        public SpellSizeLimitModel SizeLimit { get; set; }
        public int DurationId { get; set; }
        public SpellDurationModel Duration { get; set; }
        public int SaveId { get; set; }
        public SpellSaveModel Save { get; set; }
        public int CastingTimeId { get; set; }
        public SpellCastingTimeModel CastingTime { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Movement { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public int ManaBurn
        {
            get
            {
                return SpellLevel;
            }
        }
        public int ArcaneTargetNumber
        {
            get
            {
                int arcaneTargetNumber = 0;
                if (Range != null)
                    arcaneTargetNumber += Range.ArcaneValue;
                if (Area != null)
                    arcaneTargetNumber += Area.ArcaneValue;
                if (Duration != null)
                    arcaneTargetNumber += Duration.ArcaneValue;
                if (Save != null)
                    arcaneTargetNumber += Save.ArcaneValue;
                if (SizeLimit != null)
                    arcaneTargetNumber += SizeLimit.ArcaneValue;
                if (CastingTime != null)
                    arcaneTargetNumber += CastingTime.ArcaneValue;
                if (ArcanePowerAttributes.Count > 0)
                {
                    foreach (var element in ArcanePowerAttributes)
                        arcaneTargetNumber += element.ArcanePowerAttribute.ArcaneValue;
                }
                return arcaneTargetNumber;
            }
        }

        public ICollection<Spell_ArcanePowerAttribute_Link> ArcanePowerAttributes { get; set; } = new List<Spell_ArcanePowerAttribute_Link>();
        public ICollection<CharacterSheet_Spell_Link> CharacterSheets { get; set; } = new List<CharacterSheet_Spell_Link>();
    }
}