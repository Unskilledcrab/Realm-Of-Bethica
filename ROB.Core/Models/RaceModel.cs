using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class RaceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DescriptionBrief { get; set; }
        public string Description { get; set; }
        public string HeightInches { get; set; }
        public string WeightLBS { get; set; }
        public string LifeSpanYears { get; set; }
        public int Walk { get; set; }
        public int Tactical { get; set; } // called run in book
        public int Sprint { get; set; }
        public int Luck { get; set; }
        public SizeModel Size { get; set; }
        public int? FirstModifiedAttributeId { get; set; }
        public AttributeModel FirstModifiedAttribute { get; set; }
        public int FirstAttributeModifier { get; set; } = 0;
        public int? SecondModifiedAttributeId { get; set; }
        public AttributeModel SecondModifiedAttribute { get; set; }
        public int SecondAttributeModifier { get; set; } = 0;

        public ICollection<Modifier_Race_Link> Modifiers { get; set; } = new List<Modifier_Race_Link>();
    }
}
