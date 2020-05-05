namespace ROB.Web.Models
{
    public class User_PUBConGame_Link
    {
        public int PUBConGameId { get; set; }
        public PUBConGameModel PUBConGame { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
