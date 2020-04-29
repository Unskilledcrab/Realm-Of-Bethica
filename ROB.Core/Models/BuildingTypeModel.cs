namespace ROB.Core.Models
{
    public class BuildingTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BuildingSpecialtyModel BuildingSpecialty { get; set; }
    }
}
