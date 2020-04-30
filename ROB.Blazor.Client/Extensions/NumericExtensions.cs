using System;

namespace ROB.Blazor.Client.Extensions
{
    public static class NumericExtensions
    {
        public static int AsStat(this double input)
        {
            return Convert.ToInt16(Math.Round(input));
        }
    }
}
