using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROB.Discord.Helpers
{
    class UB
    {
        public static EmbedBuilder GetEmbedTemplate()
        {
            var embed = new EmbedBuilder()
                .WithFooter(footer => footer.Text = "UB Unlimited")
                .WithCurrentTimestamp();
            return embed;
        }
    }
}
