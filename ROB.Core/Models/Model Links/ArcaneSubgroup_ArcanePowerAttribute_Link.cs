namespace ROB.Core.Models
{
    public class ArcaneSubgroup_ArcanePowerAttribute_Link
    {
        public int ArcaneSubgroupId { get; set; }
        public ArcaneSubgroupModel ArcaneSubgroup { get; set; }
        public int ArcanePowerAttributeId { get; set; }
        public ArcanePowerAttributeModel ArcanePowerAttribute { get; set; }
    }
}
