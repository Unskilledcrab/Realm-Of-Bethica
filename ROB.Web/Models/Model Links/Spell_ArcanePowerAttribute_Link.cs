namespace ROB.Web.Models
{
    public class Spell_ArcanePowerAttribute_Link
    {
        public int SpellId { get; set; }
        public SpellModel Spell { get; set; }
        public int ArcanePowerAttributeId { get; set; }
        public ArcanePowerAttributeModel ArcanePowerAttribute { get; set; }
    }
}
