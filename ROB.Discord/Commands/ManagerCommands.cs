using Discord.Commands;
using ROB.Discord.Helpers;
using ROB.Discord.Secrets;
using ROB.Discord.Preconditions;
using ROB.Discord.Services;
using ROB.Core.Models;
using System.Threading.Tasks;
using static ROB.Discord.Services.TrelloService;

namespace ROB.Discord.Commands
{
    [RequireRole(nameof(DiscordSecrets.Managers))]
    public class ManagerCommands : ModuleBase<SocketCommandContext>
    {
        public TrelloService TrelloService { get; set; }

        [Command(nameof(UpdateSuggestion))]
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
        }

        [Command(nameof(GetSuggestions))]
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

        [Command(nameof(GetPendingSuggestions))]
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

        [Command(nameof(GetSuggestionById))]
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
