namespace ROB.Core.Models
{
    public class DamageTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DamageCategory Category { get; set; }
        public string Description { get; set; }
    }

    public enum DamageCategory
    {
        External,
        Internal,
        Spiritual
    }
}
