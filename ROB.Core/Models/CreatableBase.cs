using System;

namespace ROB.Core.Models
{
    public abstract class CreatableBase : ICreatable
    {
        public bool IsPublic { get; set; } = false;
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
