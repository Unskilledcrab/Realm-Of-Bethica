using Discord;
using Discord.Commands;
using ROB.Discord.Helpers;
using ROB.Discord.Preconditions;
using ROB.Discord.Secrets;
using System.Net.Security;
using System.Threading.Tasks;

namespace ROB.Discord.Commands
{
    public class EveryoneCommands : ModuleBase<SocketCommandContext>
    {
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
        [Command("testEmoji")]
        public Task EmojiAsync() => ReplyAsync("<:UBLogo:699723562071752824>");
    }
}
