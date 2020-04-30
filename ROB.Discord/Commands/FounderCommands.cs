using Discord;
using Discord.Commands;
using ROB.Discord.Helpers;
using ROB.Discord.Secrets;
using ROB.Discord.Preconditions;
using ROB.Discord.Services;
using System.Threading.Tasks;
using ROB.Web.Models;
using static ROB.Discord.Services.TrelloService;

namespace ROB.Discord.Commands
{
    [RequireRole(nameof(DiscordSecrets.Founders))]
    public class FounderCommands : ModuleBase<SocketCommandContext>
    {
        [Command(nameof(Ping))]
        public Task Ping() => ReplyAsync("pong!");

        [Command(nameof(MeetingReminder))]
        public Task MeetingReminder(string meetingAgendaURL, string team, [Remainder] string announcement)
        {
            var embed = UBTemplates.GetEmbedTemplate()
                .WithTitle($"{team} Meeting Reminder")
                .WithDescription($"{announcement}")
                .AddField("**Meeting Agenda**", $"Click [here]({meetingAgendaURL}) to view the meeting agenda." +
                $"\nPlease add anything you would like to discuss during the meeting to the agenda" +
                $"\n\nNOTE: This is an open meeting anyone who would like to join can join")
                .Build();

            return Context.Guild
                .GetTextChannel(DiscordSecrets.BethicaChatChannel)
                .SendMessageAsync($"<@&{DiscordSecrets.Staff}>", embed: embed);
        }

        [Command(nameof(FoundersMeeting))]
        public Task FoundersMeeting(string meetingAgendaURL,[Remainder] string announcement)
        {
            var embed = UBTemplates.GetEmbedTemplate()
                .WithTitle("Leads Meeting")
                .WithDescription($"{announcement}")
                .AddField("**Meeting Agenda**", $"Click [here]({meetingAgendaURL}) to view the meeting agenda." +
                $"\nPlease add anything you would like to discuss during the meeting to the agenda" +
                $"\n\nNOTE: This is a closed meeting if would like to be a part of this meeting or have something to discuss with lead, please DM a project lead")
                .Build();

            return Context.Guild
                .GetTextChannel(DiscordSecrets.BethicaChatChannel)
                .SendMessageAsync($"<@&{DiscordSecrets.Founders}>", embed: embed);
        }

        [Command(nameof(Poll))]
        public Task Poll([Remainder] string suggestion)
        {
            suggestion += $";{CommandParameters.FieldTitle}: \nRealm Creators!";
            suggestion += $";{CommandParameters.FieldDescription}: I'd love to get your input on part of the Realm I'm working on. " +
                $"\nPlease let me know what you think. " +
                $"\n\n*Note\nIf you would like to recieve notifications for new updates use the command*\n**!{nameof(RoleManagement.RealmCreator)}**" +
                $"\n*If you would like to stop recieving notification use the command*\n**!{nameof(RoleManagement.Simpleton)}**";

            var embed = UBTemplates.CreateEmbedFromCommand(suggestion);

            return Context.Guild
                .GetTextChannel(DiscordSecrets.BotTestChannel)
                .SendMessageAsync($"<@&{DiscordSecrets.Realm_Creators}>", embed: embed.Build());
        }

        [Command(nameof(MakeEmbed))]
        public Task MakeEmbed([Remainder] string command)
        {
            var embed = UBTemplates.CreateEmbedFromCommand(command);
            var rolePings = UBTemplates.GetRolePingsFromCommand(command);
            var channelId = UBTemplates.GetChannelFromCommand(command);
            var message = UBTemplates.GetMessageFromCommand(command);

            if (channelId != 1)
            {
                return Context.Guild
                    .GetTextChannel(channelId)
                    .SendMessageAsync(rolePings + message, embed: embed.Build());
            }
            else
                return ReplyAsync(rolePings + message, embed: embed.Build());
        }

    }
    [RequireRole(nameof(DiscordSecrets.Managers))]
    public class ManagerCommands : ModuleBase<SocketCommandContext>
    {
        public TrelloService TrelloService { get; set; }

        [Command(nameof(UBCommands.UpdateSuggestion))]
        public async Task UpdateSuggestion(int id, SuggestionStatus status)
        {
            var embed = UBTemplates.GetEmbedTemplate()
                .WithTitle("Suggestion Updated!")
                .WithDescription("Suggestion status is now set to: " + status)
                .WithAuthor(Context.User.Username)
                .WithCurrentTimestamp()
                .Build();

            var suggest = new SuggestionUpdate();
            suggest.SuggestionId = id;
            suggest.StatusUpdate = status;

            var result = await TrelloService.UpdateSuggestion(suggest);

            await ReplyAsync(embed: embed);
            /*
            await Context.Guild
                .GetTextChannel(DiscordSecrets.MarketingChatChannel)
                .SendMessageAsync($"<@&{DiscordSecrets.Managers}>", embed: embed);
                */
        }
        [Command(nameof(UBCommands.GetSuggestions))]
        public async Task GetSuggestions()
        {
            var suggestions = await TrelloService.GetSuggestionsAsync();

            var embed = UBTemplates.GetEmbedTemplate()
                .WithTitle("All Suggestions")
                .WithAuthor(Context.User.Username)
                .WithCurrentTimestamp();

            foreach (var suggestion in suggestions)
            {
                embed.AddField("Suggestion ID: " + suggestion.Id.ToString(), $"{suggestion.Sender} {suggestion.Suggestion} \n***Status: {suggestion.Status}***");
            }

            await ReplyAsync(embed: embed.Build());
        }
        [Command(nameof(UBCommands.GetPendingSuggestions))]
        public async Task GetPendingSuggestions()
        {
            var suggestions = await TrelloService.GetPendingSuggestions();

            var embed = UBTemplates.GetEmbedTemplate()
                .WithTitle("Suggestions Pending:")
                .WithAuthor(Context.User.Username)
                .WithCurrentTimestamp();

            foreach (var suggestion in suggestions)
            {
                embed.AddField("Suggestion ID: " + suggestion.Id.ToString(), $"{suggestion.Sender} {suggestion.Suggestion} \n***Status: {suggestion.Status}***");
            }

            await ReplyAsync(embed: embed.Build());
        }
        [Command(nameof(UBCommands.GetSuggestionById))]
        public async Task GetSuggestionById(int id)
        {
            var suggestion = await TrelloService.GetSuggestionById(id);

            var embed = UBTemplates.GetEmbedTemplate()
                .WithTitle("Suggestion with ID: " + id)
                .WithAuthor(Context.User.Username)
                .WithCurrentTimestamp();

            embed.AddField("Suggestion ID: " + suggestion.Id.ToString(), $"{suggestion.Sender} {suggestion.Suggestion} \n***Status: {suggestion.Status}***");

            await ReplyAsync(embed: embed.Build());
        }
    }
}
