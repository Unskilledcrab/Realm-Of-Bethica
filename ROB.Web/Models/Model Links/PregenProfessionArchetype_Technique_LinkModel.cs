﻿namespace ROB.Web.Models
{
    public class PregenProfessionArchetype_Technique_LinkModel
    {
        public int? PregenProfessionArchetypeId { get; set; }
        public PregenProfessionArchetypeModel PregenProfessionArchetype { get; set; }
        public int? TechniqueId { get; set; }
        public TechniqueModel Technique { get; set; }
    }
}
