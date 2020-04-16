using System;

namespace ROB.Core.Models
{
    public interface IOwnable
    {
        bool IsPublic { get; set; }
        string CreatorId { get; set; }
        ApplicationUser Creator { get; set; }
        DateTime CreationDateTime { get; set; }
        DateTime LastUpdate { get; set; }
    }

    public abstract class OwnableBase : IOwnable
    {
        public bool IsPublic { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
