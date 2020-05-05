using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using ROB.Discord.Secrets;
using System;
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
            ulong announcementChannelId = DiscordSecrets.AnnouncementChannel;
            var channel = _discord.GetChannel(announcementChannelId) as IMessageChannel;
            await channel.SendMessageAsync(embed: embed);
        }
    }
}
