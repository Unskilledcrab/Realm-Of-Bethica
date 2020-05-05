using System;
using System.ComponentModel.DataAnnotations;

namespace ROB.Web.Utilities
{
    public class OwnableModifiableModelBase : IModifiableModelBase, IOwnableBase
    {
        public int GameId { get; set; }
        public string VariableName { get; set; }
        public int OverriddenValue { get; set; }

        [MaxLength(50, ErrorMessage = "Can not be more than 50 characters")]
        public string Expression { get; set; }
        public int Priority { get; set; }
        public bool DefaultEnabled { get; set; }



        [Display(Name = "Is Public")]
        public bool IsPublic { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        /// <summary>
        /// Automatically set
        /// </summary>
        public DateTime CreationDateTime { get; set; }
        /// <summary>
        /// This must be updated
        /// </summary>
        public DateTime LastUpdate { get; set; }
    }

    public interface IModifiableBase
    {
        public int Value { get; set; }
        public int OverriddenValue { get; set; }
    }
    public class ModifiableBase : IModifiableBase
    {
        public int Value { get; set; }
        public int OverriddenValue { get; set; }
    }

    public interface IModifiableModelBase
    {
        public int GameId { get; set; }
        public int OverriddenValue { get; set; }
        public string VariableName { get; set; }
        public string Expression { get; set; }
        public int Priority { get; set; }
        public bool DefaultEnabled { get; set; }
    }
    public class ModifiableModelBase : IModifiableModelBase
    {
        public int GameId { get; set; }

        [MaxLength(5, ErrorMessage = "Can not be more than 5 characters")]
        public string VariableName { get; set; }
        public int OverriddenValue { get; set; }

        [MaxLength(50, ErrorMessage = "Can not be more than 50 characters")]
        public string Expression { get; set; }
        public int Priority { get; set; }
        public bool DefaultEnabled { get; set; }
    }

    public class GameModel : OwnableBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    /// <summary>
    /// This means that the class can be tracked down to its creator
    /// </summary>
    public interface IOwnableBase
    {
        [Display(Name = "Is Public")]
        public bool IsPublic { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        /// <summary>
        /// Automatically set
        /// </summary>
        public DateTime CreationDateTime { get; set; }
        /// <summary>
        /// This must be updated
        /// </summary>
        public DateTime LastUpdate { get; set; }
    }
    /// <summary>
    /// This means that the class can be tracked down to its creator
    /// </summary>
    public class OwnableBase
    {
        /// <summary>
        /// Is this public for anyone to use and view
        /// </summary>
        [Display(Name = "Is Public")]
        public bool IsPublic { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        /// <summary>
        /// Automatically set
        /// </summary>
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// This must be updated
        /// </summary>
        public DateTime LastUpdate { get; set; }
    }
}
