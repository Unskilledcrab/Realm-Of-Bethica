namespace ROB.Core.Models
{
    public class PregenProfessionArchetype_ChildSkill_Link
    {
        public int PregenProfessionArchetypeId { get; set; }
        public PregenProfessionArchetypeModel PregenProfessionArchetype { get; set; }
        public int ChildSkillId { get; set; }
        public ChildSkillModel ChildSkill { get; set; }
    }
}
