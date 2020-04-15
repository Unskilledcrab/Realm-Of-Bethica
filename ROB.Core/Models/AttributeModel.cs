using System.ComponentModel.DataAnnotations;

namespace ROB.Core.Models
{
    public class AttributeModel
    {
        public int Id { get; set; }

        [Display(Name = "Attribute Type")]
        public AttributeTypeModel AttributeType { get; set; }

        public string Description { get; set; }
    }

    public enum AttributeTypeModel
    {
        Strength,
        Fortitude,
        Dexterity,
        Accuracy,
        Intelligence,
        Resolve,
        Social,
        Demeanor
    }
}
