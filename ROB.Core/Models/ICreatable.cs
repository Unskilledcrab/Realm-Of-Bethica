using System;
using System.Collections;
using System.Collections.Generic;

namespace ROB.Core.Models
{
    public interface ICreatable
    {
        bool IsPublic { get; set; }
        string CreatorId { get; set; }
        ApplicationUser Creator { get; set; }
        DateTime CreationDateTime { get; set; }
        DateTime LastUpdate { get; set; }
    }
}
