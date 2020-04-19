using System;

namespace ROB.Core.Models
{
    public abstract class OwnableBase : IOwnable
    {
        public bool IsPublic { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
