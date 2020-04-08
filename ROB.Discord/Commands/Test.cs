using Discord;
using Discord.Commands;
using Discord.WebSocket;
using ROB.Discord.Helpers;
using ROB.Discord.Secrets;
using ROB.Discord.Preconditions;
using ROB.Discord.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ROB.Discord.Commands
{
    [RequireRole(UBRoles.Founders)]
    public class Test : ModuleBase<SocketCommandContext>
    {
        public TrelloService TrelloService { get; set; }

        [Command("testPing")]
        public Task PingAsync() => ReplyAsync("pong!");

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

        [Command("meetingReminder")]
        public Task MeetingReminder(string meetingAgendaURL)
        {
            var embed = UBTemplates.GetEmbedTemplate()
                .WithTitle("Meeting Reminder")
                .WithDescription("Meeting is at 6PM")
                .AddField("Meeting Agenda", $"Click [here]({meetingAgendaURL}) to view the meeting agenda")
                .Build();

            return Context.Guild
                .GetTextChannel(DiscordSecrets.BethicaChatChannel)
                .SendMessageAsync($"<@&{DiscordSecrets.Staff}>", embed: embed);
        }

        [Command("poll")]
        public Task Poll([Remainder] string suggestion)
        {
            suggestion += ";title: New Poll!";
            suggestion += ";description: I'd love to get your input on part of the Realm I'm working on. \nPlease let me know what you think below";

            var embed = UBTemplates.CreateEmbedFromCommand(suggestion);

            return Context.Guild
                .GetTextChannel(DiscordSecrets.BotTestChannel)
                .SendMessageAsync($"<@&{DiscordSecrets.Realm_Creator}>", embed: embed.Build());
        }

        [Command("makeEmbed")]
        public Task MakeEmbed([Remainder] string command)
        {
            var embed = UBTemplates.CreateEmbedFromCommand(command);
            var rolePings = UBTemplates.GetRolePingsFromCommand(command);
            var channelId = UBTemplates.GetChannelFromCommand(command);

            if (channelId != 1)
            {
                return Context.Guild
                    .GetTextChannel(channelId)
                    .SendMessageAsync(rolePings, embed: embed.Build());
            }
            else
                return ReplyAsync(rolePings, embed: embed.Build());
        }
    }
}
