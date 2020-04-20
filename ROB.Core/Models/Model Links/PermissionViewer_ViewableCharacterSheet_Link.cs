namespace ROB.Core.Models
{
    public class PermissionViewer_ViewableCharacterSheet_Link
    {
        public int ViewableCharacterSheetId { get; set; }
        public CharacterSheetModel ViewableCharacterSheet { get; set; }
        public string PermissionViewerId { get; set; }
        public ApplicationUser PermissionViewer { get; set; }
    }
}
