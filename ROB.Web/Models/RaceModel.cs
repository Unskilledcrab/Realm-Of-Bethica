using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROB.Web.Models
{
    public class RaceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Description Brief")]
        [MaxLength(50,ErrorMessage ="Can not be more than 50 characters")]
        public string DescriptionBrief { get; set; }
        public string Description { get; set; }
        [Display(Name = "Height")]
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string HeightInches { get; set; }
        [Display(Name = "Weight")]
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string WeightLBS { get; set; }
        [Display(Name = "Life Span")]
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string LifeSpanYears { get; set; }
        public int Walk { get; set; }
        public int Tactical { get; set; } // called run in book
        public int Sprint { get; set; }
        public int Luck { get; set; }
        public SizeModel Size { get; set; }

        [Display(Name = "First Modified Attribute")]
        public int? FirstModifiedAttributeId { get; set; }
        public AttributeModel FirstModifiedAttribute { get; set; }
        [Display(Name = "First Modifier")]
        public int FirstAttributeModifier { get; set; } = 0;

        public int? SecondModifiedAttributeId { get; set; }
        [Display(Name = "Second Modified Attribute")]
        public AttributeModel SecondModifiedAttribute { get; set; }
        [Display(Name = "First Modifier")]
        public int SecondAttributeModifier { get; set; } = 0;

        public ICollection<Modifier_Race_Link> Modifiers { get; set; } = new List<Modifier_Race_Link>();
    }
}
