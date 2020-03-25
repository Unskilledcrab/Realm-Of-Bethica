using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using ROB.Discord.Models.Secrets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ROB.Discord.API
{
    public class APIHandler
    {
        private readonly DiscordSocketClient _discord;

        public APIHandler(IServiceProvider services)
        {
            _discord = services.GetRequiredService<DiscordSocketClient>();
        }

        public async Task AnnouncementAsync(Embed embed)
        {
            ulong announcementChannelId = DiscordSecrets.AnnouncementChannelId;
            var channel = _discord.GetChannel(announcementChannelId) as IMessageChannel;
            await channel.SendMessageAsync(embed: embed);
        }
    }
}
