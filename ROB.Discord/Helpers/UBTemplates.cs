using Discord;
using ROB.Discord.Secrets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROB.Discord.Helpers
{
    class UBTemplates
    {
        public static EmbedBuilder GetEmbedTemplate()
        {
            var embed = new EmbedBuilder()
                .WithColor(Color.Blue)
                .WithFooter(footer => footer.Text = "UB Unlimited")
                .WithCurrentTimestamp();
            return embed;
        }

        private static string[] ParseCommand(string commandString)
        {
            commandString = commandString.Replace('"', '\"'); // replace escape characters
            var commands = commandString.Split(';');

            foreach (var command in commands)
                command.Trim();

            return commands;
        }

        public static string GetMessageFromCommand(string commandString)
        {
            var commands = ParseCommand(commandString);

            string message = "";

            for (int i = 0; i < commands.Length; i++)
            {
                var command = commands[i].Split(':');

                if (command.Length == 1)
                    throw new Exception($"The command {commands[i]} is not formatted correctly you must use \":\" colons to seperate the field and text");

                var section = command[0].Trim();
                var text = command[1].Trim();
                if (section == CommandParameters.Message) message = text;
            }
            return message;
        }

        public static EmbedBuilder CreateEmbedFromCommand(string commandString)
        {
            var embed = GetEmbedTemplate();

            var commands = ParseCommand(commandString);

            string title = "";
            string description = "";
            var fieldTitle = new List<string>();
            var fieldDesc = new List<string>();

            for (int i = 0; i < commands.Length; i++)
            {
                var command = commands[i].Split(':');

                if (command.Length == 1)
                    throw new Exception($"The command {commands[i]} is not formatted correctly you must use \":\" colons to seperate the field and text");

                var section = command[0].Trim();
                var text = command[1].Trim();
                if (section == CommandParameters.Title) title = text;
                else if (section == CommandParameters.Description) description = text;
                else if (section == CommandParameters.FieldTitle) fieldTitle.Add(text);
                else if (section == CommandParameters.FieldDescription) fieldDesc.Add(text);
            }

            if (title != "")
                embed.WithTitle(title);

            if (description != "")
                embed.WithDescription(description);

            for (int i = 0; i < fieldTitle.Count; i++)
            {
                if (fieldDesc.Count == i)
                    throw new Exception("The number of fieldTitle's and fieldDesc do not match");

                embed.AddField(fieldTitle[i], fieldDesc[i]);
            }
            return embed;
        }

        public static string GetRolePingsFromCommand(string commandString)
        {
            var commands = ParseCommand(commandString);

            var rolePings = new StringBuilder();
            for (int i = 0; i < commands.Length; i++)
            {
                var command = commands[i].Split(':');

                var section = command[0].Trim();
                if (section == CommandParameters.Roles)
                {
                    if (command.Length == 1)
                        throw new Exception($"The command {commands[i]} is not formatted correctly you must use \":\" colons to seperate the field and text");

                    var roles = command[1].Trim().Split(" ");
                    foreach (var role in roles)
                    {
                        var text = role.Trim();

                        if (text.Equals(nameof(DiscordSecrets.Everyone), StringComparison.InvariantCultureIgnoreCase))
                            rolePings.Append($" <@&{DiscordSecrets.Everyone}>");
                        else if (text.Equals(nameof(DiscordSecrets.Moderators), StringComparison.InvariantCultureIgnoreCase))
                            rolePings.Append($" <@&{DiscordSecrets.Moderators}>");
                        else if (text.Equals(nameof(DiscordSecrets.Recruits), StringComparison.InvariantCultureIgnoreCase))
                            rolePings.Append($" <@&{DiscordSecrets.Recruits}>");
                        else if (text.Equals(nameof(DiscordSecrets.Alpha_Testers), StringComparison.InvariantCultureIgnoreCase))
                            rolePings.Append($" <@&{DiscordSecrets.Alpha_Testers}>");
                        else if (text.Equals(nameof(DiscordSecrets.Beta_Testers), StringComparison.InvariantCultureIgnoreCase))
                            rolePings.Append($" <@&{DiscordSecrets.Beta_Testers}>");
                        else if (text.Equals(nameof(DiscordSecrets.Staff), StringComparison.InvariantCultureIgnoreCase))
                            rolePings.Append($" <@&{DiscordSecrets.Staff}>");
                        else if (text.Equals(nameof(DiscordSecrets.Managers), StringComparison.InvariantCultureIgnoreCase))
                            rolePings.Append($" <@&{DiscordSecrets.Managers}>");
                        else if (text.Equals(nameof(DiscordSecrets.Marketers), StringComparison.InvariantCultureIgnoreCase))
                            rolePings.Append($" <@&{DiscordSecrets.Marketers}>");
                        else if (text.Equals(nameof(DiscordSecrets.Web_Designers), StringComparison.InvariantCultureIgnoreCase))
                            rolePings.Append($" <@&{DiscordSecrets.Web_Designers}>");
                        else if (text.Equals(nameof(DiscordSecrets.Developers), StringComparison.InvariantCultureIgnoreCase))
                            rolePings.Append($" <@&{DiscordSecrets.Developers}>");
                        else if (text.Equals(nameof(DiscordSecrets.Founders), StringComparison.InvariantCultureIgnoreCase))
                            rolePings.Append($" <@&{DiscordSecrets.Founders}>");
                        else if (text.Equals(nameof(DiscordSecrets.Realm_Creators), StringComparison.InvariantCultureIgnoreCase))
                            rolePings.Append($" <@&{DiscordSecrets.Realm_Creators}>");
                        else
                            throw new Exception($"The role {role} either can not be pinged or is not formatted correctly.\nUse a \";\" to seperate commands. \nMake sure there are no spaces in the role name");
                    }
                }
            }
            return rolePings.ToString();
        }

        public static ulong GetChannelFromCommand(string commandString)
        {
            var commands = ParseCommand(commandString);

            for (int i = 0; i < commands.Length; i++)
            {
                var command = commands[i].Split(':');

                var section = command[0].Trim();
                if (section == CommandParameters.Channel)
                {
                    if (command.Length == 1)
                        throw new Exception($"The command {commands[i]} is not formatted correctly you must use \":\" colons to seperate the field and text");

                    var channel = command[1].Trim().ToLower();
                    if (channel.Equals(nameof(DiscordSecrets.AnnouncementChannel), StringComparison.InvariantCultureIgnoreCase))
                        return DiscordSecrets.AnnouncementChannel;
                    else if (channel.Equals(nameof(DiscordSecrets.BethicaChatChannel), StringComparison.InvariantCultureIgnoreCase))
                        return DiscordSecrets.BethicaChatChannel;
                    else if (channel.Equals(nameof(DiscordSecrets.GeneralChannel), StringComparison.InvariantCultureIgnoreCase))
                        return DiscordSecrets.GeneralChannel;
                    else if (channel.Equals(nameof(DiscordSecrets.BotTestChannel), StringComparison.InvariantCultureIgnoreCase))
                        return DiscordSecrets.BotTestChannel;
                    else
                        throw new Exception($"The channel {channel} either does not exist or is not formatted correctly.\nUse a \";\" to seperate commands. \nBe sure to remove all \"-\"s and place \"channel\" at the end of the channel name");

                }
            }
            return 1;
        }
    }
}
