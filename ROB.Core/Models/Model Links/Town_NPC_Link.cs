namespace ROB.Core.Models
{
    public class Town_NPC_Link
    {
        public int NPCId { get; set; }
        public CharacterSheetModel NPC { get; set; }
        public int NPCTownId { get; set; }
        public TownModel NPCTown { get; set; }
    }
}
