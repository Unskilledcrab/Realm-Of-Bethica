using Discord;
using Discord.Commands;
using ROB.Discord.Helpers;
using ROB.Discord.Preconditions;
using ROB.Discord.Secrets;
using System.Threading.Tasks;

namespace ROB.Discord.Commands
{
    [RequireRole(nameof(DiscordSecrets.Staff))]
    public class StaffCommands : ModuleBase<SocketCommandContext>
    {
        [Command(nameof(Absent))]
        public Task Absent(string cardURL, [Remainder] string helpRequired)
        {
            var embed = new EmbedBuilder()
                .WithColor(Color.Blue)
                .WithCurrentTimestamp()
                .WithTitle($"{Context.User.Username} Absent Update")
                .WithDescription($"[Task]({cardURL}): {helpRequired}")
                .Build();
            
                return Context.Guild
                    .GetTextChannel(DiscordSecrets.AbsentUpdateChannel)
                    .SendMessageAsync($"<@&{DiscordSecrets.Managers}>", embed: embed);
        }
    }
}
