﻿using Discord;
using Discord.Commands;
using ROB.Discord.Helpers;
using ROB.Discord.Preconditions;
using ROB.Discord.Secrets;
using ROB.Discord.Services;
using ROB.Web.Models;
using System.Net.Security;
using System.Threading.Tasks;

namespace ROB.Discord.Commands
{
    public class EveryoneCommands : ModuleBase<SocketCommandContext>
    {
        public TrelloService TrelloService { get; set; }

        [Command(nameof(UBCommands.Socials))]
        public Task Socials()
        {
            var embed = new EmbedBuilder()
                .WithTitle("Socials")
                .WithDescription("Follow us on our social media accounts!")
                .AddField("Testing Socials", "<:UBLogo:699723562071752824> testing ")
                .WithAuthor(Context.Client.CurrentUser)
                .WithFooter(footer => footer.Text = "UB Unlimited")
                .WithCurrentTimestamp()
                .Build();

            return ReplyAsync(embed: embed);
        }
        [Command(nameof(UBCommands.Suggest))]
        public async Task Suggest([Remainder] string suggestion)
        {
            var stream = await TrelloService.GetSuggestionsAsync();

            var embed = UBTemplates.GetEmbedTemplate()
                .WithTitle("Suggestion")
                .AddField("My Suggestion is:", $"{suggestion}")
                .WithAuthor(Context.User.Username)
                .WithCurrentTimestamp()
                .Build();

            var suggest = new TrelloSuggestionModel();
            suggest.Sender = Context.User.Mention;
            suggest.Suggestion = suggestion;

            suggest = await TrelloService.SendSuggestion(suggest);

            await ReplyAsync($"{suggest.Sender} your suggestion has been recorded!", embed: embed);
            /*
            await Context.Guild
                .GetTextChannel(DiscordSecrets.MarketingChatChannel)
                .SendMessageAsync($"<@&{DiscordSecrets.Managers}>", embed: embed);
                */
            /*
            return Context.Guild
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
                embed.AddField("Suggestion ID: " + suggestion.Id.ToString(), suggestion.Sender + suggestion.Suggestion);
            }

            await ReplyAsync("Data received", embed: embed.Build());
        }
    }
}
