using ROBaspCore.Models;

namespace ROBaspCore.ViewModels
{
    public class CharacterDetailsViewModel
    {
        public string Background { get; set; }
        public Alignment Alignment { get; set; }
        public string Gender { get; set; }
        public string Faith { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int HeightInches { get; set; }
    }
}
