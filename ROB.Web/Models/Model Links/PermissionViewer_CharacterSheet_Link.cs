namespace ROB.Web.Models
{
    public class PermissionViewer_CharacterSheet_Link
    {
        public int CharacterSheetId { get; set; }
        public CharacterSheetModel CharacterSheet { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
