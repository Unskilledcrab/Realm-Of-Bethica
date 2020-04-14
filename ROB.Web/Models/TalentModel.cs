using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROB.Web.Models
{
    public class TalentModel
    {
        public int Id { get; set; }
        [Display(Name = "Talent Group")]
        public int TalentGroupId { get; set; }
        public TalentGroupTypeModel TalentGroup { get; set; }
        [MaxLength(50, ErrorMessage = "Can not be more than 50 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Benefit { get; set; }

        [MaxLength(500, ErrorMessage = "Can not be more than 500 characters")]
        public string Notes { get; set; }
        public int Cost { get; set; } = 1;

        public ICollection<TalentPrerequisiteLink> TalentPrerequisites { get; set; } = new List<TalentPrerequisiteLink>();
        public ICollection<TalentPrerequisiteLink> TalentBases { get; set; } = new List<TalentPrerequisiteLink>();
        public ICollection<TechniqueTalentPrerequisiteLink> TechniqueConnection { get; set; } = new List<TechniqueTalentPrerequisiteLink>();
        public ICollection<PregenProfessionArchetype_Talent_LinkModel> PregenProfessionArchetypeLink { get; set; } = new List<PregenProfessionArchetype_Talent_LinkModel>();
        public ICollection<CharacterSheet_Talent_Link> CharacterSheets { get; set; } = new List<CharacterSheet_Talent_Link>();

    }
}
