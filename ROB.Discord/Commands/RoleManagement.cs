using Discord;
using Discord.Commands;
using ROB.Discord.Helpers;
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
        private List<string> RealmCreatorGainComments = new List<string>()
        {
            $"You have been successfully granted the role of {nameof(DiscordSecrets.Realm_Creators)}.",
            $"You gain in statue as you ascend to the role of {nameof(DiscordSecrets.Realm_Creators)}."
        };

        private List<string> RealmCreatorLossComments = new List<string>()
        {
            $"You have had your title of {nameof(DiscordSecrets.Realm_Creators)} stripped from you. People laugh as you walk by"
        };

        private string RandomRealmCreatorGainComment()
        {
            var rand = new Random();
            int selection = rand.Next(0, RealmCreatorGainComments.Count);
            return RealmCreatorGainComments[selection];
        }

        private string RandomRealmCreatorLossComment()
        {
            var rand = new Random();
            int selection = rand.Next(0, RealmCreatorLossComments.Count);
            return RealmCreatorLossComments[selection];
        }

        [Command(nameof(UBCommands.RealmCreator))]
        public async Task RealmCreator()
        {
            var user = Context.User;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == nameof(DiscordSecrets.Realm_Creators));
            await (user as IGuildUser).AddRoleAsync(role);
            await ReplyAsync($"{RandomRealmCreatorGainComment()}\nIf you want to neglect your new role and hide from your responsibilies use the command \"!{nameof(UBCommands.Simpleton)}\"");
        }

        [Command(nameof(UBCommands.Simpleton))]
        public async Task Simpleton()
        {
            var user = Context.User;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == nameof(DiscordSecrets.Realm_Creators));
            await (user as IGuildUser).RemoveRoleAsync(role);
            await ReplyAsync(RandomRealmCreatorLossComment());
        }
    }
}
