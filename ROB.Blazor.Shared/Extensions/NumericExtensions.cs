using System;

namespace ROB.Blazor.Shared.Extensions
{
    public static class NumericExtensions
    {
        public static int AsStat(this double input)
        {
            return Convert.ToInt16(Math.Round(input));
        }
    }
}
