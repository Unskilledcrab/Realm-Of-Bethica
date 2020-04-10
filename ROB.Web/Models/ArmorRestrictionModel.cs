using System.ComponentModel.DataAnnotations;

namespace ROB.Web.Models
{
    public class ArmorRestrictionModel
    {
        public int Id { get; set; }

        [Display(Name = "Armor Restriction Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Feat Value Penalty")]
        public int FeatValuePenalty { get; set; }

        [Display(Name = "Casting Penalty")]
        public int CastingPenalty { get; set; }

        [Display(Name = "Evasion Penalty")]
        public int EvasionPenalty { get; set; }

        [Display(Name = "Movement Penalty")]
        public int MovementPenalty { get; set; }
    }
}
