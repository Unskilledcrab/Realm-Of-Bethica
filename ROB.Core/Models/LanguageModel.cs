namespace ROB.Core.Models
{
    public class LanguageModel
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }
        public int GroupTypeId { get; set; } // Entity framework generates this automatically on the DB side but you still need in class
        public LanguageGroupTypeModel GroupType { get; set; }
        public string TypeName { get; set; }
        public bool Written { get; set; } // Is this language a written language?
    }
}