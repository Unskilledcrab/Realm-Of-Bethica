﻿using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class SpellSaveModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArcaneValue { get; set; }
        public string Description { get; set; }
        public ICollection<SpellModel> Spells { get; set; } = new List<SpellModel>();
    }
}
