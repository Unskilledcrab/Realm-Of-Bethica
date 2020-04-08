using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using ROB.Core;
using ROB.Discord.Secrets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ROB.Discord.Services
{
    public class TrelloService
    {
        private readonly DiscordSocketClient _discord;
        private readonly HttpClient _http;

        public TrelloService(HttpClient http, IServiceProvider services)
        {
            _discord = services.GetRequiredService<DiscordSocketClient>();
            _http = http; ;
        }

        public Task SendUBAnnouncement(Embed embed)
        {
            var guild = _discord.GetGuild(DiscordSecrets.GuildId);
            var announcementChannel = guild.GetTextChannel(DiscordSecrets.AnnouncementChannel);
            return announcementChannel.SendMessageAsync(embed: embed);
        }
    }
}
