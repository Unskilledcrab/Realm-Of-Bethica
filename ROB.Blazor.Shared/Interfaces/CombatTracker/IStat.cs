using System;
using System.Collections.Generic;
using System.Text;

namespace ROB.Blazor.Shared.Interfaces.CombatTracker
{
    public interface IStat
    {
        string Name { get; set; }
        string Abbreviation { get; set; }
        int Value { get; set; }
    }
}
