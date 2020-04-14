namespace ROB.Web.Models
{
    public class PregenProfessionArchetype_ChildSkill_LinkModel
    {
        public int? PregenProfessionArchetypeId { get; set; }
        public PregenProfessionArchetypeModel PregenProfessionArchetype { get; set; }
        public int? ChildSkillId { get; set; }
        public ChildSkillModel ChildSkill { get; set; }
    }
}
