using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ROB.Discord.Commands
{
    public class Test : ModuleBase<SocketCommandContext>
    {
        [Command("testPing")]
        public Task PingAsync() => ReplyAsync("pong!");
        
        public async Task EmbedToChannelAsync(Embed embed, ulong channelId)
        {
            DiscordSocketClient client = new DiscordSocketClient();
            var channel = client.GetChannel(channelId) as IMessageChannel;
            await channel.SendMessageAsync(embed: embed);
        }

        [Command("testEmbed")]
        public Task TestEmbed()
        {
            var embed = new EmbedBuilder()
                .WithTitle("Test Title")
                .WithDescription("Test Description")
                .AddField("Trello Board", "Click [here](https://trello.com/developers78278598) to go to trello home")
                .WithAuthor(Context.Client.CurrentUser)
                .WithFooter(footer => footer.Text = "UB Unlimited")
                .WithCurrentTimestamp()
                .Build();

            return ReplyAsync(embed: embed);
        }
    }
}
