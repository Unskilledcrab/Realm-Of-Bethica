using Discord;
using Discord.Commands;
using ROB.Discord.Secrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROB.Discord.Commands
{
    public class RoleManagement : ModuleBase<SocketCommandContext>
    {

        [Command("RealmCreator")]
        public async Task RealmCreator()
        {
            var user = Context.User;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == nameof(DiscordSecrets.Realm_Creator));
            await (user as IGuildUser).AddRoleAsync(role);
            await ReplyAsync($"You have been successfully granted the role of {nameof(DiscordSecrets.Realm_Creator)}.\nIf you want to neglect your new role and hide from your responsibilies use the command \"Simpleton\"");
        }

        [Command("Simpleton")]
        public async Task Simpleton()
        {
            var user = Context.User;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == nameof(DiscordSecrets.Realm_Creator));
            await (user as IGuildUser).RemoveRoleAsync(role);
            await ReplyAsync($"You have had your title of {nameof(DiscordSecrets.Realm_Creator)} stripped from you. People laugh as you walk by");
        }
    }
}
