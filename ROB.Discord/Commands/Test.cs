using Discord;
using Discord.Commands;
using Discord.WebSocket;
using ROB.Discord.Helpers;
using ROB.Discord.Models.Secrets;
using ROB.Discord.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ROB.Discord.Commands
{
    public class Test : ModuleBase<SocketCommandContext>
    {
        public TrelloService TrelloService { get; set; }

        [Command("testPing")]
        [RequireUserPermission(GuildPermission.Administrator, Group = "Permission")]
        public Task PingAsync() => ReplyAsync("pong!");

        [Command("testEmbed")]
        [RequireUserPermission(GuildPermission.Administrator, Group = "Permission")]
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
        [RequireUserPermission(GuildPermission.Administrator, Group = "Permission")]
        public Task MeetingReminder(string meetingAgendaURL)
        {
            var embed = UB.GetEmbedTemplate()
                .WithTitle("Meeting Reminder")
                .WithDescription("Meeting is at 6PM")
                .AddField("Meeting Agenda", $"Click [here]({meetingAgendaURL}) to view the meeting agenda")
                .Build();

            //return ReplyAsync($"<@&{DiscordSecrets.StaffId}>", embed: embed);
            return Context.Guild
                .GetTextChannel(DiscordSecrets.BethicaChatId)
                .SendMessageAsync($"<@&{DiscordSecrets.StaffId}>", embed: embed);
        }
    }
}
