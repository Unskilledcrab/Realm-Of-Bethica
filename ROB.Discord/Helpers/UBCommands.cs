namespace ROB.Discord.Helpers
{
    /// <summary>
    /// This class should be used with ALL commands so that we can statically reference them throughout the project
    /// Make sure that the Property and string match EXACTLY
    /// </summary>
    public class UBCommands
    {
        // Test Commands
        public static readonly string Poll = "Poll";
        public static readonly string MeetingReminder = "MeetingReminder";
        public static readonly string MakeEmbed = "MakeEmbed";

        // Role Management Commands
        public static readonly string RealmCreator = "RealmCreator";
        public static readonly string Simpleton = "Simpleton";

        // Staff Commands
        public static readonly string Absent = "Absent";
        public static readonly string Vote = "Vote";
        public static readonly string GetSuggestions = "GetSuggestions";
        public static readonly string GetSenderSuggestions = "GetSenderSuggestions";
        public static readonly string GetPendingSuggestions = "GetPendingSuggestions";
        public static readonly string GetSuggestionById = "GetSuggestionById";
        public static readonly string GetSuggestionsByUserMention = "GetSuggestionsByUserMention";
        public static readonly string UpdateSuggestion = "UpdateSuggestion";

        // Everyone Commands
        public static readonly string Socials = "Socials";
        public static readonly string Suggest = "Suggest";

    }
}
